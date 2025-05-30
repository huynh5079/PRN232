using Lab02_ODataBookAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab02_ODataBookAPI.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Press> Presses { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relationships
            modelBuilder.Entity<Press>()
                .HasOne(p => p.Address)
                .WithMany(a => a.Presses)
                .HasForeignKey(p => p.AddressId);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Press)
                .WithMany(p => p.Books)
                .HasForeignKey(b => b.PressId);

            // Sample Seed Data
            modelBuilder.Entity<Address>().HasData(
                new Address { AddressId = 1, City = "Hanoi", Country = "Vietnam" },
                new Address { AddressId = 2, City = "Tokyo", Country = "Japan" }
            );

            modelBuilder.Entity<Press>().HasData(
                new Press { PressId = 1, Name = "FPT Press", Category = "Education", AddressId = 1 },
                new Press { PressId = 2, Name = "Manga House", Category = "Comics", AddressId = 2 }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book { BookId = 1, Title = "Learn C#", Author = "Nguyen A", Price = 99.5, PressId = 1 },
                new Book { BookId = 2, Title = "ASP.NET Core Guide", Author = "Le B", Price = 120, PressId = 1 },
                new Book { BookId = 3, Title = "Naruto Vol.1", Author = "Masashi K", Price = 50, PressId = 2 }
            );
        }
    }
}
