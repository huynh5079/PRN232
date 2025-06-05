using System.ComponentModel.DataAnnotations;

namespace NguyenManhTanHuynh_SE17D05_A01_BE.DTOs
{
    public class SignUpRequestDto
    {
        [Required(ErrorMessage = "Account name is required")]
        [StringLength(100, ErrorMessage = "Account name cannot exceed 100 characters")]
        public string AccountName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Account email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        [StringLength(100, ErrorMessage = "Account email cannot exceed 100 characters")]
        public string AccountEmail { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 100 characters")]
        public string Password { get; set; } = string.Empty;

        // AccountRole is optional for signup if you have a default user role
        // Otherwise, it might be required and validated
        [Range(0, 2, ErrorMessage = "Account role must be between 0 (Admin), 1 (Staff), or 2 (Lecturer)")]
        public int AccountRole { get; set; } = 1; // Default to Staff for new signups
    }
}