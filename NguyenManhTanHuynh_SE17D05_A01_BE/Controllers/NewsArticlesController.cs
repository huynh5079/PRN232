using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using DataLayer.Entities;
using System.Security.Claims;
using DataLayer.Services;
using NguyenManhTanHuynh_SE17D05_A01_BE.DTOs;

namespace NguyenManhTanHuynh_SE17D05_A01_BE.Controllers
{
    [Route("odata/NewsArticles")]
    [Authorize(Roles = "Admin, Staff,Lecture")]
    public class NewsArticlesController : ControllerBase
    {
        private readonly INewsArticleService _newsArticleService;

        public NewsArticlesController(INewsArticleService newsArticleService)
        {
            _newsArticleService = newsArticleService;
        }
        [AllowAnonymous]
        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> Get()
        {
            var newsArticles = await _newsArticleService.GetAllNewsArticlesAsync();
            return Ok(newsArticles);
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        [EnableQuery]
        public async Task<IActionResult> Get(string id)
        {
            var newsArticle = await _newsArticleService.GetNewsArticleByIdAsync(id);
            if (newsArticle == null)
                return NotFound();
            return Ok(newsArticle);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateNewsArticleDto newsArticleDto) 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                return Unauthorized("User ID not found in token.");

            // Map DTO to Entity
            var newsArticle = new NewsArticle
            {
                NewsTitle = newsArticleDto.NewsTitle,
                NewsContent = newsArticleDto.NewsContent,
                NewsStatus = newsArticleDto.NewsStatus,
                CategoryId = newsArticleDto.CategoryId,
                CreatedById = userId, //  authenticated user
            };

            try
            {
                await _newsArticleService.CreateNewsArticleAsync(newsArticle, userId);
                return CreatedAtAction(nameof(Get), new { id = newsArticle.Id }, newsArticle);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] UpdateNewsArticleDto newsArticleDto) 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                return Unauthorized("User ID not found in token.");

            try
            {
                var existingNewsArticle = await _newsArticleService.GetNewsArticleByIdAsync(id);
                if (existingNewsArticle == null)
                {
                    return NotFound("News article not found.");
                }

                if (newsArticleDto.NewsTitle != null) existingNewsArticle.NewsTitle = newsArticleDto.NewsTitle;
                if (newsArticleDto.NewsContent != null) existingNewsArticle.NewsContent = newsArticleDto.NewsContent;
                if (newsArticleDto.NewsStatus.HasValue) existingNewsArticle.NewsStatus = newsArticleDto.NewsStatus.Value;
                if (newsArticleDto.CategoryId != null) existingNewsArticle.CategoryId = newsArticleDto.CategoryId;
                //if (newsArticleDto.CreatedById != null) existingNewsArticle.CreatedById = newsArticleDto.CreatedById;


                // Pass the updated entity 
                await _newsArticleService.UpdateNewsArticleAsync(existingNewsArticle, userId);
                return NoContent();
            }
            catch (UnauthorizedAccessException ex) // Catch specific auth errors
            {
                return Forbid(ex.Message); // Return 403 Forbidden
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin, Staff, Lecture")] 
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _newsArticleService.DeleteNewsArticleAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}