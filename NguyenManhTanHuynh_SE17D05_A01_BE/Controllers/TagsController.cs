using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Formatter;
using DataLayer.Entities;
using DataLayer.Services;
using NguyenManhTanHuynh_SE17D05_A01_BE.DTOs;

namespace NguyenManhTanHuynh_SE17D05_A01_BE.Controllers
{
    [Route("odata/[controller]")]
    [Authorize(Roles = "Admin, Staff")]
    public class TagsController : ODataController
    {
        private readonly ITagService _tagService;

        public TagsController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [EnableQuery]
        public async Task<IActionResult> Get()
        {
            var tags = await _tagService.GetAllTagsAsync();
            return Ok(tags);
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromODataUri] string key)
        {
            var tag = await _tagService.GetTagByIdAsync(key);
            if (tag == null)
                return NotFound();
            return Ok(tag);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTagDto tagDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var tag = new Tag { TagName = tagDto.TagName }; // Map DTO to Entity

            try
            {
                await _tagService.CreateTagAsync(tag);
                return Created(tag);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromODataUri] string id, [FromBody] UpdateTagDto tagDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var existingTag = await _tagService.GetTagByIdAsync(id);
                if (existingTag == null)
                {
                    return NotFound("Tag not found.");
                }

                if (tagDto.TagName != null) existingTag.TagName = tagDto.TagName;

                await _tagService.UpdateTagAsync(existingTag);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromODataUri] string id)
        {
            try
            {
                await _tagService.DeleteTagAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}