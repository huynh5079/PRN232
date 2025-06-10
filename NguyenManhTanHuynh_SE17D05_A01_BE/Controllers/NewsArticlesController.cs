using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Formatter;
using DataLayer.Entities;
using System.Security.Claims;
using BusinessLayer.Services;
using DataLayer.DTOs;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace NguyenManhTanHuynh_SE17D05_A01_BE.Controllers
{
    [Route("odata/NewsArticles")]
    //[Authorize(Roles = "Admin, Staff, Lecturer")] 
    public class NewsArticlesController : ODataController
    {
        private readonly INewsArticleService _newsArticleService;

        public NewsArticlesController(INewsArticleService newsArticleService)
        {
            _newsArticleService = newsArticleService;
        }

        [AllowAnonymous]
        //[HttpGet]
        [EnableQuery]
        public async Task<IActionResult> Get()
        {
            var newsArticles = await _newsArticleService.GetAllNewsArticlesAsync(onlyActive: true);
            return Ok(newsArticles);
        }

        [AllowAnonymous]
        //[HttpGet("{id}")]
        [EnableQuery]
        public async Task<IActionResult> GetNewsArticle([FromODataUri] string id) // Renamed method
        {
            var newsArticle = await _newsArticleService.GetNewsArticleByIdAsync(id, onlyActive: true);
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

            var newsArticle = new NewsArticle
            {
                NewsTitle = newsArticleDto.NewsTitle,
                NewsContent = newsArticleDto.NewsContent,
                NewsStatus = newsArticleDto.NewsStatus,
                CategoryId = newsArticleDto.CategoryId,
                CreatedById = userId,
                NewsTags = newsArticleDto.TagIds.Select(tagId => new NewsTag { TagId = tagId }).ToList() // Map TagIds
            };

            try
            {
                await _newsArticleService.CreateNewsArticleAsync(newsArticle, userId);
                return Created(newsArticle); // ODataController's Created helper
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromODataUri] string id, [FromBody] UpdateNewsArticleDto newsArticleDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                return Unauthorized("User ID not found in token.");

            try
            {
                var existingNewsArticle = await _newsArticleService.GetNewsArticleByIdAsync(id, includes: q => q.Include(na => na.NewsTags));
                if (existingNewsArticle == null)
                {
                    return NotFound("News article not found.");
                }

                if (newsArticleDto.NewsTitle != null) existingNewsArticle.NewsTitle = newsArticleDto.NewsTitle;
                if (newsArticleDto.NewsContent != null) existingNewsArticle.NewsContent = newsArticleDto.NewsContent;
                if (newsArticleDto.NewsStatus.HasValue) existingNewsArticle.NewsStatus = newsArticleDto.NewsStatus.Value;
                if (newsArticleDto.CategoryId != null) existingNewsArticle.CategoryId = newsArticleDto.CategoryId;

                if (newsArticleDto.TagIds != null)
                {
                    existingNewsArticle.NewsTags = newsArticleDto.TagIds.Select(tagId => new NewsTag { TagId = tagId, NewsArticleId = existingNewsArticle.Id }).ToList();
                }

                await _newsArticleService.UpdateNewsArticleAsync(existingNewsArticle, userId, newsArticleDto.CreatedById);
                return NoContent();
            }
            catch (UnauthorizedAccessException ex)
            {
                return Forbid(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "Admin, Staff, Lecturer")]
        public async Task<IActionResult> Delete([FromODataUri] string id)
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