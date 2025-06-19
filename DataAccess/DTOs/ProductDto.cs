using System.ComponentModel.DataAnnotations;

namespace DataAccess.DTOs
{
    public class ProductDto
    {
        public int ProductId { get; set; } 

        [Required(ErrorMessage = "Product Name is required.")]
        [StringLength(255, ErrorMessage = "Product Name cannot exceed 255 characters.")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, 9999999999999999.99, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }

        // public string Description { get; set; }
    }
}