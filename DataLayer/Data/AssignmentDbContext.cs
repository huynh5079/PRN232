using System;
using System.Collections.Generic;
using System.Linq; // Ensure this is included
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using DataLayer.Utilities; // Make sure this is included for PasswordHasher

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
            // --- Entity Configurations (Relationships and Indexes) ---
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

            var random = new Random(); // Initialize Random once for all seeding

            // 1. SystemAccounts
            var adminAccountId = "8908368e-4567-460c-bba9-38b60d8f225f"; // Consistent ID for Admin
            var seededAdminAccount = new SystemAccount
            {
                Id = adminAccountId,
                AccountName = "Admin",
                AccountEmail = "admin@FUNewsManagementSystem.org",
                AccountPassword = PasswordHasher.HashPassword("@@abc123@@"),
                AccountRole = 0, // Admin
                CreatedAt = DateTime.UtcNow.AddYears(-1),
                UpdatedAt = DateTime.UtcNow.AddYears(-1)
            };
            modelBuilder.Entity<SystemAccount>().HasData(seededAdminAccount);

            var systemAccounts = new List<SystemAccount>();
            for (int i = 1; i <= 10; i++) // 10 Staff Members
            {
                systemAccounts.Add(new SystemAccount
                {
                    Id = Guid.NewGuid().ToString(),
                    AccountName = $"Staff Member {i}",
                    AccountEmail = $"staff{i}@fuedu.vn",
                    AccountPassword = PasswordHasher.HashPassword($"StaffPass{i}!"),
                    AccountRole = 1, // Staff
                    CreatedAt = DateTime.UtcNow.AddMonths(-random.Next(1, 12)),
                    UpdatedAt = DateTime.UtcNow.AddMonths(-random.Next(1, 12))
                });
            }
            for (int i = 1; i <= 10; i++) // 10 Lecturers
            {
                systemAccounts.Add(new SystemAccount
                {
                    Id = Guid.NewGuid().ToString(),
                    AccountName = $"Lecturer {i}",
                    AccountEmail = $"lecturer{i}@fuedu.vn",
                    AccountPassword = PasswordHasher.HashPassword($"LecPass{i}!"),
                    AccountRole = 2, // Lecturer
                    CreatedAt = DateTime.UtcNow.AddMonths(-random.Next(1, 12)),
                    UpdatedAt = DateTime.UtcNow.AddMonths(-random.Next(1, 12))
                });
            }
            modelBuilder.Entity<SystemAccount>().HasData(systemAccounts);

            // Collect all account IDs for NewsArticle creation
            var allAccountIds = new List<string> { adminAccountId };
            allAccountIds.AddRange(systemAccounts.Select(sa => sa.Id));


            // 2. Categories
            var categories = new List<Category>();
            for (int i = 1; i <= 20; i++)
            {
                categories.Add(new Category
                {
                    Id = Guid.NewGuid().ToString(),
                    CategoryName = $"Category {i}",
                    CategoryDescription = $"Description for category {i} of university news.",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow.AddMonths(-random.Next(1, 12)),
                    UpdatedAt = DateTime.UtcNow.AddMonths(-random.Next(1, 12))
                });
            }
            modelBuilder.Entity<Category>().HasData(categories);
            var categoryIds = categories.Select(c => c.Id).ToList();


            // 3. Tags
            var tags = new List<Tag>();
            string[] commonTags = { "Technology", "Research", "StudentLife", "CampusNews", "Events",
                                    "Sports", "Academics", "Alumni", "International", "Admissions",
                                    "Scholarships", "Career", "Health", "Sustainability", "Arts",
                                    "Science", "Engineering", "Business", "Humanities", "Community" };

            for (int i = 0; i < commonTags.Length; i++)
            {
                tags.Add(new Tag
                {
                    Id = Guid.NewGuid().ToString(),
                    TagName = commonTags[i],
                    Note = $"General note for {commonTags[i]} tag.",
                    CreatedAt = DateTime.UtcNow.AddMonths(-random.Next(1, 12)),
                    UpdatedAt = DateTime.UtcNow.AddMonths(-random.Next(1, 12))
                });
            }
            for (int i = 1; i <= 5; i++) // Add 5 more generic tags
            {
                tags.Add(new Tag
                {
                    Id = Guid.NewGuid().ToString(),
                    TagName = $"Generic Tag {i}",
                    Note = $"Note for generic tag {i}.",
                    CreatedAt = DateTime.UtcNow.AddMonths(-random.Next(1, 12)),
                    UpdatedAt = DateTime.UtcNow.AddMonths(-random.Next(1, 12))
                });
            }
            modelBuilder.Entity<Tag>().HasData(tags); // <--- Only one HasData call for Tags
            var tagIds = tags.Select(t => t.Id).ToList(); // <--- Correctly placed after 'tags' list is built


            // 4. NewsArticles
            var newsArticles = new List<NewsArticle>();
            for (int i = 1; i <= 25; i++) // Creating 25 articles
            {
                var createdBy = allAccountIds[random.Next(allAccountIds.Count)];
                var category = categoryIds[random.Next(categoryIds.Count)];
                var createdDate = DateTime.UtcNow.AddDays(-random.Next(1, 365));

                newsArticles.Add(new NewsArticle
                {
                    Id = Guid.NewGuid().ToString(),
                    NewsTitle = $"University Update: Article {i} - {Guid.NewGuid().ToString().Substring(0, 8)}",
                    NewsContent = $"This is the detailed content for news article {i}. It covers important developments and announcements within the university community. Stay tuned for more updates! This article aims to inform students, faculty, and staff about recent achievements and upcoming events. We value our community's engagement.",
                    CreatedDate = createdDate,
                    NewsStatus = random.Next(0, 2) == 1, // true for active, false for inactive
                    CategoryId = category,
                    CreatedById = createdBy,
                    CreatedAt = createdDate.AddHours(-1),
                    UpdatedAt = createdDate.AddMinutes(random.Next(1, 60))
                });
            }
            modelBuilder.Entity<NewsArticle>().HasData(newsArticles);
            var newsArticleIds = newsArticles.Select(na => na.Id).ToList();


            // 5. NewsTags (Create associations for NewsArticles, 2-5 tags per article)
            var newsTags = new List<NewsTag>();
            foreach (var articleId in newsArticleIds)
            {
                // Randomly select 2 to 5 unique tags for each article
                // Ensure there are enough tags to pick from
                if (tagIds.Count > 0)
                {
                    var numTagsToSelect = Math.Min(random.Next(2, 6), tagIds.Count); // Ensure we don't try to take more tags than available
                    var selectedTagIds = tagIds.OrderBy(x => random.Next()).Take(numTagsToSelect).ToList();
                    foreach (var tagId in selectedTagIds)
                    {
                        newsTags.Add(new NewsTag
                        {
                            NewsArticleId = articleId,
                            TagId = tagId
                        });
                    }
                }
            }
            modelBuilder.Entity<NewsTag>().HasData(newsTags);
        }
    }
}