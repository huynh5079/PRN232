using DataLayer.Entities;
using BusinessLayer.Repositories;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BusinessLayer.Services
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
            Func<IQueryable<NewsArticle>, IQueryable<NewsArticle>>? includes = null,
            bool onlyActive = false)
        {
            Expression<Func<NewsArticle, bool>>? combinedFilter = filter;
            if (onlyActive)
            {
                if (combinedFilter == null)
                {
                    combinedFilter = na => na.NewsStatus == true;
                }
                else
                {
                    var parameter = combinedFilter.Parameters.Single();
                    var activeCondition = Expression.Lambda<Func<NewsArticle, bool>>(
                        Expression.Property(parameter, nameof(NewsArticle.NewsStatus)), parameter);
                    combinedFilter = Expression.Lambda<Func<NewsArticle, bool>>(
                        Expression.AndAlso(combinedFilter.Body, activeCondition.Body),
                        parameter);
                }
            }
            return await _newsArticleRepository.GetAllAsync(combinedFilter, includes);
        }

        public async Task<NewsArticle?> GetNewsArticleByIdAsync(string id,
            Func<IQueryable<NewsArticle>, IQueryable<NewsArticle>>? includes = null,
            bool onlyActive = false)
        {
            if (includes == null)
            {
                includes = query => query.Include(na => na.Category).Include(na => na.CreatedBy).Include(na => na.NewsTags).ThenInclude(nt => nt.Tag);
            }

            Expression<Func<NewsArticle, bool>> finalFilter = na => na.Id == id;
            if (onlyActive)
            {
                var parameter = finalFilter.Parameters.Single();
                var activeCondition = Expression.Lambda<Func<NewsArticle, bool>>(
                    Expression.Property(parameter, nameof(NewsArticle.NewsStatus)), parameter);
                finalFilter = Expression.Lambda<Func<NewsArticle, bool>>(
                    Expression.AndAlso(finalFilter.Body, activeCondition.Body),
                    parameter);
            }

            return await _newsArticleRepository.GetAsync(finalFilter, includes);
        }

        public async Task CreateNewsArticleAsync(NewsArticle newsArticle, string? userId)
        {
            var categoryExists = await _categoryRepository.GetAsync(c => c.Id == newsArticle.CategoryId);
            if (categoryExists == null)
            {
                throw new Exception("Invalid Category ID provided.");
            }

            var creatorExists = await _systemAccountRepository.GetAsync(sa => sa.Id == userId);
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

        public async Task UpdateNewsArticleAsync(NewsArticle newsArticle, string? callingUserId, string? newCreatedById = null)
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

                if (callingAccount.AccountRole != 0 && // Not an Admin
                    callingAccount.AccountRole != 1 && // Not Staff
                    callingAccount.AccountRole != 2) // Not Lecturer
                {
                    throw new UnauthorizedAccessException("You are not authorized to update news articles.");
                }

                if (newCreatedById != null && existingNewsArticle.CreatedById != newCreatedById)
                {
                    if (callingAccount.AccountRole != 0) // Not Admin
                    {
                        throw new UnauthorizedAccessException("Only administrators can change the news article creator.");
                    }
                    var newCreatorExists = await _systemAccountRepository.GetAsync(sa => sa.Id == newCreatedById);
                    if (newCreatorExists == null)
                    {
                        throw new Exception("Invalid New Creator ID provided.");
                    }
                    existingNewsArticle.CreatedById = newCreatedById; // Update creator if Admin allowed
                }
                else if (newCreatedById == null)
                {
                    existingNewsArticle.CreatedById = existingNewsArticle.CreatedById; // Keep existing
                }
                else
                {
                    existingNewsArticle.CreatedById = newCreatedById;
                }
            }
            else
            {
                throw new UnauthorizedAccessException("Authentication required.");
            }


            // Update category ID if changed and valid
            if (newsArticle.CategoryId != null && existingNewsArticle.CategoryId != newsArticle.CategoryId)
            {
                var categoryExists = await _categoryRepository.GetAsync(c => c.Id == newsArticle.CategoryId);
                if (categoryExists == null) throw new Exception("Invalid Category ID provided.");
                existingNewsArticle.CategoryId = newsArticle.CategoryId;
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
            existingNewsArticle.UpdatedAt = DateTime.UtcNow;

            await _newsArticleRepository.UpdateAsync(existingNewsArticle);
            await _newsArticleRepository.SaveAsync();
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

            await _newsArticleRepository.RemoveAsync(newsArticle);
            await _newsArticleRepository.SaveAsync();
        }
    }
}