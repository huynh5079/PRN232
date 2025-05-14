using APIExamplePRN232.Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace APIExamplePRN232.Data.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        { }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().HasData(
                new Student { StudentID = 1, StudentName = "John Doe", StudentAddress = "123 Main St" },
                new Student { StudentID = 2, StudentName = "Jane Smith", StudentAddress = "456 Oak Ave" },
                new Student { StudentID = 3, StudentName = "Michael Brown", StudentAddress = "789 Elm Dr" },
                new Student { StudentID = 4, StudentName = "Emily Johnson", StudentAddress = "321 Birch Ln" },
                new Student { StudentID = 5, StudentName = "David Lee", StudentAddress = "654 Pine Rd" },
                new Student { StudentID = 6, StudentName = "Sarah Wilson", StudentAddress = "987 Maple St" },
                new Student { StudentID = 7, StudentName = "Robert Martinez", StudentAddress = "741 Cedar Blvd" },
                new Student { StudentID = 8, StudentName = "Laura White", StudentAddress = "852 Ash St" },
                new Student { StudentID = 9, StudentName = "Kevin Harris", StudentAddress = "159 Spruce Ave" },
                new Student { StudentID = 10, StudentName = "Sophia Clark", StudentAddress = "753 Redwood Blvd" },
                new Student { StudentID = 11, StudentName = "Daniel King", StudentAddress = "264 Chestnut Ct" },
                new Student { StudentID = 12, StudentName = "Olivia Lewis", StudentAddress = "978 Acacia Rd" },
                new Student { StudentID = 13, StudentName = "James Hall", StudentAddress = "183 Magnolia Ln" },
                new Student { StudentID = 14, StudentName = "Mia Allen", StudentAddress = "365 Willow St" },
                new Student { StudentID = 15, StudentName = "William Young", StudentAddress = "572 Poplar Rd" },
                new Student { StudentID = 16, StudentName = "Emma Turner", StudentAddress = "492 Cypress Blvd" },
                new Student { StudentID = 17, StudentName = "Henry Scott", StudentAddress = "611 Cherry St" },
                new Student { StudentID = 18, StudentName = "Alice Adams", StudentAddress = "284 Fir Ave" },
                new Student { StudentID = 19, StudentName = "Benjamin Carter", StudentAddress = "705 Juniper Ct" },
                new Student { StudentID = 20, StudentName = "Ella Baker", StudentAddress = "840 Dogwood Blvd" }
            );
        }

    }
}
