using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Data
{
    public class SP25PEDBContext : DbContext
    {
        public SP25PEDBContext(DbContextOptions<SP25PEDBContext> options) : base(options)
        {
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Enrollments> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
            });

            modelBuilder.Entity<Courses>(entity =>
            {
                entity.HasOne(c => c.Category)
                      .WithMany(cat => cat.Courses)
                      .HasForeignKey(c => c.CategoryId)
                      .OnDelete(DeleteBehavior.Restrict); 

                entity.HasOne(c => c.User)
                      .WithMany(u => u.Courses)
                      .HasForeignKey(c => c.UserId)
                      .OnDelete(DeleteBehavior.Restrict); 
            });

            modelBuilder.Entity<Enrollments>(entity =>
            {
                entity.HasIndex(e => new { e.UserId, e.CourseId }).IsUnique();

                entity.HasOne(e => e.User)
                      .WithMany(u => u.Enrollments)
                      .HasForeignKey(e => e.UserId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Course)
                      .WithMany(c => c.Enrollments)
                      .HasForeignKey(e => e.CourseId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            var seedDate = new DateTime(2025, 6, 11, 3, 0, 0, DateTimeKind.Utc);

            // 1. Seed Categories
            modelBuilder.Entity<Categories>().HasData(
                new Categories { CategoryId = 1, CategoryName = "Kỹ năng mềm" },
                new Categories { CategoryId = 2, CategoryName = "Phát triển bản thân" },
                new Categories { CategoryId = 3, CategoryName = "Kỹ năng chuyên môn" }
            );

            // 2. Seed Users
            modelBuilder.Entity<Users>().HasData(
                new Users
                {
                    UserId = 1,
                    Email = "teacher@example.com",
                    Password = "123123"
                },
                new Users
                {
                    UserId = 2,
                    Email = "student@example.com",
                    Password = "123123"
                }
            );

            // 3. Seed Courses
            modelBuilder.Entity<Courses>().HasData(
                new Courses
                {
                    CoursesId = 1,
                    Title = "Giao tiếp hiệu quả",
                    Description = "Cải thiện kỹ năng lắng nghe và trình bày.",
                    Price = 500000m,
                    CreatedAt = seedDate,
                    CategoryId = 1, // Foreign Key 
                    UserId = 1       // Foreign Key 
                },
                new Courses
                {
                    CoursesId = 2,
                    Title = "Quản lý thời gian thông minh",
                    Description = "Học cách sắp xếp công việc và cuộc sống.",
                    Price = 650000m,
                    CreatedAt = seedDate,
                    CategoryId = 2, // Foreign Key
                    UserId = 1       // Foreign Key 
                },
                new Courses
                {
                    CoursesId = 3,
                    Title = "Làm việc nhóm chuyên nghiệp",
                    Description = "Phối hợp hiệu quả để đạt mục tiêu chung.",
                    Price = 550000m,
                    CreatedAt = seedDate,
                    CategoryId = 1, // Foreign Key 
                    UserId = 1       // Foreign Key 
                },
                new Courses
                {
                    CoursesId = 4,
                    Title = "Tư duy phản biện",
                    Description = "Phân tích thông tin và ra quyết định logic.",
                    Price = 700000m,
                    CreatedAt = seedDate,
                    CategoryId = 2, // Foreign Key
                    UserId = 1       // Foreign Key
                },
                new Courses
                {
                    CoursesId = 5,
                    Title = "Nhập môn Lập trình C#",
                    Description = "Các khái niệm cơ bản về C# và .NET.",
                    Price = 990000m,
                    CreatedAt = seedDate,
                    CategoryId = 3, // Foreign Key 
                    UserId = 1       // Foreign Key
                }
            );
        }
    }
}