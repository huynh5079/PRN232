using System.ComponentModel.DataAnnotations;

namespace DataLayer.DTOs
{
    public class CreateTagDto
    {
        [Required(ErrorMessage = "Tag name is required.")]
        [StringLength(50, ErrorMessage = "Tag name cannot exceed 50 characters.")]
        public string TagName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Tag note is required.")]
        [StringLength(255, ErrorMessage = "Tag note cannot exceed 255 characters.")]
        public string Note { get; set; } = string.Empty;
    }
}