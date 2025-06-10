using System.ComponentModel.DataAnnotations;

namespace DataLayer.DTOs
{
    public class UpdateAccountDto
    {
        [StringLength(100, ErrorMessage = "Account name cannot exceed 100 characters.")]
        public string? AccountName { get; set; }

        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 100 characters.")]
        public string? NewPassword { get; set; } 

        [Range(0, 2, ErrorMessage = "Account role must be between 0 (Admin), 1 (Staff), or 2 (Lecturer).")]
        public int? AccountRole { get; set; }
    }
}