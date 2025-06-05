// NguyenManhTanHuynh_SE17D05_A01_BE/Controllers/CategoriesController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Formatter;
using DataLayer.Entities;
using DataLayer.Services;
using NguyenManhTanHuynh_SE17D05_A01_BE.DTOs; // <--- ADD THIS USING STATEMENT

namespace NguyenManhTanHuynh_SE17D05_A01_BE.Controllers
{
    [Route("odata/[controller]")]
    [Authorize(Roles = "Admin, Staff, Lecturer")] // <--- Updated roles for clarity based on your assignment
    public class CategoriesController : ODataController
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [EnableQuery]
        public async Task<IActionResult> Get()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }

        [EnableQuery]
        public async Task<IActionResult> Get([FromODataUri] string key)
        {
            var category = await _categoryService.GetCategoryByIdAsync(key);
            if (category == null)
                return NotFound();
            return Ok(category);
        }

        [HttpPost] 
        public async Task<IActionResult> Post([FromBody] CreateCategoryDto categoryDto) 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Map DTO to Entity
            var category = new Category
            {
                CategoryName = categoryDto.CategoryName,
                CategoryDescription = categoryDto.CategoryDescription,
                IsActive = categoryDto.IsActive,
                // Id, CreatedAt, UpdatedAt handled by BaseEntity/Service
            };

            try
            {
                await _categoryService.CreateCategoryAsync(category);
                return Created(category); // Return the created entity
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromODataUri] string id, [FromBody] UpdateCategoryDto categoryDto) 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                // get exist category to update
                var existingCategory = await _categoryService.GetCategoryByIdAsync(id);
                if (existingCategory == null)
                {
                    return NotFound("Category not found.");
                }

                // Map DTO properties to the existing entity
                if (categoryDto.CategoryName != null) existingCategory.CategoryName = categoryDto.CategoryName;
                if (categoryDto.CategoryDescription != null) existingCategory.CategoryDescription = categoryDto.CategoryDescription;
                if (categoryDto.IsActive.HasValue) existingCategory.IsActive = categoryDto.IsActive.Value;

                await _categoryService.UpdateCategoryAsync(existingCategory);
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
                await _categoryService.DeleteCategoryAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}