using System.ComponentModel.DataAnnotations;

namespace DataLayer.DTOs
{
    public class CourseUpdateDto
    {
        [Required(ErrorMessage = "Title is required")]
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(100)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive number")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Category ID is required")]
        public int CategoryId { get; set; }
    }
}