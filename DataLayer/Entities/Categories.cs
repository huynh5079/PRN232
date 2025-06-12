using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities
{
    public class Categories
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Category name cannot be blank")]
        [MaxLength(100)]
        public string CategoryName { get; set; }

        // Navigation property
        public virtual ICollection<Courses> Courses { get; set; } = new List<Courses>();

    }
}