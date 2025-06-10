using System.ComponentModel.DataAnnotations;

namespace DataLayer.DTOs
{
    public class UpdateTagDto
    {
        [StringLength(50, ErrorMessage = "Tag name cannot exceed 50 characters.")]
        public string? TagName { get; set; }

        [StringLength(255, ErrorMessage = "Tag note cannot exceed 255 characters.")]
        public string? Note { get; set; }
    }
}