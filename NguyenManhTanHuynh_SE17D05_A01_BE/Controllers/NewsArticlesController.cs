using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using DataLayer.Entities;
using System.Security.Claims;
using NguyenManhTanHuynh_SE17D05_A01_BE.Services;

namespace NguyenManhTanHuynh_SE17D05_A01_BE.Controllers
{
    [Route("odata/NewsArticles")]
    [Authorize]
    public class NewsArticlesController : ControllerBase
    {
        private readonly INewsArticleService _newsArticleService;

        public NewsArticlesController(INewsArticleService newsArticleService)
        {
            _newsArticleService = newsArticleService;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> Get()
        {
            var newsArticles = await _newsArticleService.GetAllAsync();
            return Ok(newsArticles);
        }

        [HttpGet("{id}")]
        [EnableQuery]
        public async Task<IActionResult> Get(string id)
        {
            var newsArticle = await _newsArticleService.GetByIdAsync(id);
            if (newsArticle == null)
                return NotFound();
            return Ok(newsArticle);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] NewsArticle newsArticle)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            try
            {
                await _newsArticleService.CreateAsync(newsArticle, userId);
                return CreatedAtAction(nameof(Get), new { id = newsArticle.Id }, newsArticle);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] NewsArticle newsArticle)
        {
            if (id != newsArticle.Id)
                return BadRequest("ID mismatch");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            try
            {
                await _newsArticleService.UpdateAsync(newsArticle, userId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _newsArticleService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}