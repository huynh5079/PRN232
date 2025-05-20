using eStoreWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace eStoreWebAPI.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Electronics" },
                new Category { CategoryId = 2, CategoryName = "Books" },
                new Category { CategoryId = 3, CategoryName = "Clothing" },
                new Category { CategoryId = 4, CategoryName = "Groceries" },
                new Category { CategoryId = 5, CategoryName = "Toys" }
            );

            // Sample products
            var products = new List<Product>();
            for (int i = 1; i <= 20; i++)
            {
                products.Add(new Product
                {
                    ProductId = i,
                    ProductName = $"Sample Product {i}",
                    UnitPrice = 10.99m + i,
                    UnitsInStock = 100 + i,
                    CategoryId = (i % 5) + 1
                });
            }
            modelBuilder.Entity<Product>().HasData(products.ToArray());
        }
    }
}
