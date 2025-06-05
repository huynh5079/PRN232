using System.ComponentModel.DataAnnotations;

namespace NguyenManhTanHuynh_SE17D05_A01_BE.DTOs
{
    public class CreateTagDto
    {
        [Required(ErrorMessage = "Tag name is required.")]
        [StringLength(50, ErrorMessage = "Tag name cannot exceed 50 characters.")]
        public string TagName { get; set; } = string.Empty;
    }
}