using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Data
{
    public class AssignmentDbContext : DbContext
    {
        public DbSet<SystemAccount> SystemAccounts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<NewsArticle> NewsArticles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<NewsTag> NewsTags { get; set; }

        public AssignmentDbContext(DbContextOptions<AssignmentDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NewsTag>()
                .HasKey(nt => new { nt.NewsArticleId, nt.TagId });

            modelBuilder.Entity<NewsTag>()
                .HasOne(nt => nt.NewsArticle)
                .WithMany(na => na.NewsTags)
                .HasForeignKey(nt => nt.NewsArticleId);

            modelBuilder.Entity<NewsTag>()
                .HasOne(nt => nt.Tag)
                .WithMany(t => t.NewsTags)
                .HasForeignKey(nt => nt.TagId);

            modelBuilder.Entity<SystemAccount>()
                .HasIndex(a => a.AccountEmail)
                .IsUnique();

            modelBuilder.Entity<NewsArticle>()
                .HasIndex(na => na.NewsTitle);

            // Seed default Admin account
            modelBuilder.Entity<SystemAccount>().HasData(
                new SystemAccount
                {
                    Id = Guid.NewGuid().ToString(),
                    AccountName = "Admin",
                    AccountEmail = "admin@FUNewsManagementSystem.org",
                    AccountPassword = "@@abc123@@",
                    AccountRole = 0, // 0 for Admin
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );
        }
    }
}
