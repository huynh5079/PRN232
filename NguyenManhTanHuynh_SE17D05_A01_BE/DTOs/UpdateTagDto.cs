using System.ComponentModel.DataAnnotations;

namespace NguyenManhTanHuynh_SE17D05_A01_BE.DTOs
{
    public class UpdateTagDto
    {
        [StringLength(50, ErrorMessage = "Tag name cannot exceed 50 characters.")]
        public string? TagName { get; set; } // Nullable if optional update
    }
}