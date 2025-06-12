using System.ComponentModel.DataAnnotations;

namespace DataLayer.DTOs
{
    public class CategoryUpdateDto
    {
        [Required]
        [MaxLength(100)]
        public string CategoryName { get; set; }
    }
}