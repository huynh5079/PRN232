using DataLayer.Entities;
using DataLayer.Repositories; 
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataLayer.Services
{
    public class NewsArticleService : INewsArticleService
    {
        private readonly IGenericRepository<NewsArticle> _newsArticleRepository;
        private readonly IGenericRepository<Category> _categoryRepository; 
        private readonly IGenericRepository<SystemAccount> _systemAccountRepository;
        private readonly IGenericRepository<Tag> _tagRepository;
        private readonly IGenericRepository<NewsTag> _newsTagRepository;

        public NewsArticleService(
            IGenericRepository<NewsArticle> newsArticleRepository,
            IGenericRepository<Category> categoryRepository,
            IGenericRepository<SystemAccount> systemAccountRepository,
            IGenericRepository<Tag> tagRepository,
            IGenericRepository<NewsTag> newsTagRepository)

        {
            _newsArticleRepository = newsArticleRepository;
            _categoryRepository = categoryRepository;
            _systemAccountRepository = systemAccountRepository;
            _tagRepository = tagRepository;
            _newsTagRepository = newsTagRepository;
        }

        public async Task<IEnumerable<NewsArticle>> GetAllNewsArticlesAsync(
            Expression<Func<NewsArticle, bool>>? filter = null,
            Func<IQueryable<NewsArticle>, IQueryable<NewsArticle>>? includes = null)
        {
            if (includes == null)
            {
                includes = query => query.Include(na => na.Category).Include(na => na.CreatedBy);
            }

            return await _newsArticleRepository.GetAllAsync(filter, includes);
        }

        public async Task<NewsArticle?> GetNewsArticleByIdAsync(string id,
            Func<IQueryable<NewsArticle>, IQueryable<NewsArticle>>? includes = null)
        {
            if (includes == null)
            {
                includes = query => query.Include(na => na.Category).Include(na => na.CreatedBy).Include(na => na.NewsTags).ThenInclude(nt => nt.Tag);
            }

            return await _newsArticleRepository.GetAsync(na => na.Id == id, includes);
        }

        public async Task CreateNewsArticleAsync(NewsArticle newsArticle, string? userId)
        {
            var categoryExists = await _categoryRepository.GetAsync(c => c.Id == newsArticle.CategoryId);
            if (categoryExists == null)
            {
                throw new Exception("Invalid Category ID provided.");
            }

            var creatorExists = await _systemAccountRepository.GetAsync(sa => sa.Id == userId); // Use userId here for creatorExists check
            if (creatorExists == null)
            {
                throw new Exception("Invalid Creator ID provided or user not found.");
            }

            if (newsArticle.NewsTags != null && newsArticle.NewsTags.Any())
            {
                foreach (var newsTag in newsArticle.NewsTags)
                {
                    var tagExists = await _tagRepository.GetAsync(t => t.Id == newsTag.TagId);
                    if (tagExists == null)
                    {
                        throw new Exception($"Invalid Tag ID provided: {newsTag.TagId}");
                    }
                }
            }

            newsArticle.CreatedById = userId;

            newsArticle.CreatedDate = DateTime.UtcNow;

            await _newsArticleRepository.CreateAsync(newsArticle);
            await _newsArticleRepository.SaveAsync();
        }

        public async Task UpdateNewsArticleAsync(NewsArticle newsArticle, string? callingUserId)
        {
            var existingNewsArticle = await _newsArticleRepository.GetAsync(na => na.Id == newsArticle.Id,
            query => query.Include(na => na.NewsTags)); 
            if (existingNewsArticle == null)
            {
                throw new Exception("News article not found.");
            }

            if (!string.IsNullOrEmpty(callingUserId))
            {
                var callingAccount = await _systemAccountRepository.GetAsync(sa => sa.Id == callingUserId);

                if (callingAccount == null)
                {
                    throw new UnauthorizedAccessException("User not found or invalid token.");
                }

                if (callingAccount.AccountRole != 0 && callingAccount.AccountRole != 1 && callingAccount.AccountRole != 3 && existingNewsArticle.CreatedById != callingUserId)
                {
                    throw new UnauthorizedAccessException("You are not authorized to update this news article.");
                }
            }
            else
            {
                throw new UnauthorizedAccessException("Authentication required.");
            }

            if (newsArticle.CategoryId != null && existingNewsArticle.CategoryId != newsArticle.CategoryId)
            {
                var categoryExists = await _categoryRepository.GetAsync(c => c.Id == newsArticle.CategoryId);
                if (categoryExists == null) throw new Exception("Invalid Category ID provided.");
            }

            // 2. Handle changing CreatedById
            if (newsArticle.CreatedById != null && existingNewsArticle.CreatedById != newsArticle.CreatedById)
            {
                var callingAccount = await _systemAccountRepository.GetAsync(sa => sa.Id == callingUserId);
                if (callingAccount == null || callingAccount.AccountRole != 0) throw new UnauthorizedAccessException("Only administrators can change the news article creator.");
                var newCreatorExists = await _systemAccountRepository.GetAsync(sa => sa.Id == newsArticle.CreatedById);
                if (newCreatorExists == null) throw new Exception("Invalid New Creator ID provided.");
            }
            else
            {
                newsArticle.CreatedById = existingNewsArticle.CreatedById; 
            }

            if (newsArticle.NewsTags != null) 
            {
                existingNewsArticle.NewsTags.Clear(); 

                foreach (var newNewsTag in newsArticle.NewsTags)
                {
                    var tagExists = await _tagRepository.GetAsync(t => t.Id == newNewsTag.TagId);
                    if (tagExists == null)
                    {
                        throw new Exception($"Invalid Tag ID provided: {newNewsTag.TagId}");
                    }
                    existingNewsArticle.NewsTags.Add(new NewsTag
                    {
                        NewsArticleId = existingNewsArticle.Id, 
                        TagId = newNewsTag.TagId
                    });
                }
            }

            existingNewsArticle.NewsTitle = newsArticle.NewsTitle;
            existingNewsArticle.NewsContent = newsArticle.NewsContent;
            existingNewsArticle.NewsStatus = newsArticle.NewsStatus;
            existingNewsArticle.CategoryId = newsArticle.CategoryId;
            existingNewsArticle.UpdatedAt = DateTime.UtcNow;

            await _newsArticleRepository.UpdateAsync(existingNewsArticle); // Update the main article
            await _newsArticleRepository.SaveAsync(); // Save all changes, including NewsTags
        }

        public async Task DeleteNewsArticleAsync(string id)
        {
            var newsArticle = await _newsArticleRepository.GetAsync(
                na => na.Id == id,
                query => query.Include(na => na.NewsTags)
            );

            if (newsArticle == null)
            {
                throw new Exception("News article not found.");
            }

            if (newsArticle.NewsTags != null && newsArticle.NewsTags.Any())
            {
                throw new Exception("Cannot delete news article because it has associated tags.");
            }

            // If the article has no tags, proceed with deletion.
            await _newsArticleRepository.RemoveAsync(newsArticle);
            await _newsArticleRepository.SaveAsync();
        }
    }
}