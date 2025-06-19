using System.ComponentModel.DataAnnotations;

namespace DataAccess
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [MaxLength(255)]
        public string ProductName { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}