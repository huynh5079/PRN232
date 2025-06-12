using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities
{
    public class Enrollments
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EnrollmentId { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public virtual Courses Course { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual Users User { get; set; }
    }
}