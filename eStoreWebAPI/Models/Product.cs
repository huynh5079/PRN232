using System.ComponentModel.DataAnnotations;

namespace eStoreWebAPI.Models
{
    public class Product

    {
        public int ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Range(0, double.MaxValue)]
        public decimal UnitPrice { get; set; }

        [Range(0, int.MaxValue)]
        public int UnitsInStock { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
