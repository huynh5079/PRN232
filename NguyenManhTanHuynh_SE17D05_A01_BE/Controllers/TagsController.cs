using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Formatter;
using DataLayer.Entities;
using BusinessLayer.Services;
using DataLayer.DTOs;

namespace NguyenManhTanHuynh_SE17D05_A01_BE.Controllers
{
    [Route("odata/[controller]")]
    //[Authorize(Roles = "Admin, Staff, Lecturer")] 
    public class TagsController : ODataController
    {
        private readonly ITagService _tagService;

        public TagsController(ITagService tagService)
        {
            _tagService = tagService;
        }

        //[HttpGet]
        [EnableQuery]
        public async Task<IActionResult> Get()
        {
            var tags = await _tagService.GetAllTagsAsync();
            return Ok(tags);
        }

        //[HttpGet("{key}")] // OData key convention
        [EnableQuery]
        public async Task<IActionResult> GetTag([FromODataUri] string key) // 'Get' to  'GetTag'
        {
            var tag = await _tagService.GetTagByIdAsync(key);
            if (tag == null)
                return NotFound();
            return Ok(tag);
        }

        //[HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTagDto tagDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var tag = new Tag
            {
                TagName = tagDto.TagName,
                Note = tagDto.Note
            };

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
                if (tagDto.Note != null) existingTag.Note = tagDto.Note; 

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