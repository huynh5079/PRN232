using System.ComponentModel.DataAnnotations;

namespace DataLayer.DTOs
{
    public class CreateCategoryDto
    {
        [Required(ErrorMessage = "Category name is required.")]
        [StringLength(100, ErrorMessage = "Category name cannot exceed 100 characters.")]
        public string CategoryName { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Category description cannot exceed 500 characters.")]
        public string? CategoryDescription { get; set; } // Nullable if optional

        public bool IsActive { get; set; } = true; // Default to active
    }
}