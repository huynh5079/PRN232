using System.ComponentModel.DataAnnotations;

namespace DataLayer.DTOs
{
    public class EnrollmentCreateDto
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int CourseId { get; set; }
    }
}