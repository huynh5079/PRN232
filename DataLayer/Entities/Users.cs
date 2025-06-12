using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string Password { get; set; }

        // Navigation properties
        public virtual ICollection<Courses> Courses { get; set; } = new HashSet<Courses>();     
        public virtual ICollection<Enrollments> Enrollments { get; set; } = new HashSet<Enrollments>();
    }
}