using DataLayer.Entities;
using System.Linq.Expressions;
using System.Linq;

namespace BusinessLayer.Services
{
    public interface INewsArticleService
    {
        Task<IEnumerable<NewsArticle>> GetAllNewsArticlesAsync(
            Expression<Func<NewsArticle, bool>>? filter = null,
            Func<IQueryable<NewsArticle>, IQueryable<NewsArticle>>? includes = null,
            bool onlyActive = false);

        Task<NewsArticle?> GetNewsArticleByIdAsync(string id,
            Func<IQueryable<NewsArticle>, IQueryable<NewsArticle>>? includes = null,
            bool onlyActive = false);

        Task CreateNewsArticleAsync(NewsArticle newsArticle, string? userId);

        Task UpdateNewsArticleAsync(NewsArticle newsArticle, string? callingUserId, string? newCreatedById = null); // Added newCreatedById

        Task DeleteNewsArticleAsync(string id);
    }
}