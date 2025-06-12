using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities
{
    public class Courses
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CoursesId { get; set; }

        [Required(ErrorMessage = "Title cannot be blank")]
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(100)]
        public string? Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Categories Category { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual Users User { get; set; }

        // Navigation property
        public virtual ICollection<Enrollments> Enrollments { get; set; } = new HashSet<Enrollments>();
    }
}