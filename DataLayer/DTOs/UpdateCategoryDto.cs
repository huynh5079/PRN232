using System.ComponentModel.DataAnnotations;

namespace DataLayer.DTOs
{
    public class UpdateCategoryDto
    {
        [StringLength(100, ErrorMessage = "Category name cannot exceed 100 characters.")]
        public string? CategoryName { get; set; }

        [StringLength(500, ErrorMessage = "Category description cannot exceed 500 characters.")]
        public string? CategoryDescription { get; set; }

        public bool? IsActive { get; set; } // Nullable if optional update
    }
}