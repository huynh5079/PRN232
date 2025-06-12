using System.ComponentModel.DataAnnotations;

namespace DataLayer.DTOs
{
    public class CategoryCreateDto
    {
        [Required]
        [MaxLength(100)]
        public string CategoryName { get; set; }
    }
}