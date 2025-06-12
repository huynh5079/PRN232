using System.ComponentModel.DataAnnotations;

namespace DataLayer.DTOs
{
    public class UserRegisterDto
    {
        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(100)]
        public string Password { get; set; }
    }
}