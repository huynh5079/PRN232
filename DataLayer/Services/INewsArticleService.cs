using DataLayer.Entities;
using DataLayer.Repositories;
using System.Linq.Expressions;

namespace DataLayer.Services
{
    public interface INewsArticleService
    {
        Task<IEnumerable<NewsArticle>> GetAllNewsArticlesAsync(
            Expression<Func<NewsArticle, bool>>? filter = null,
            Func<IQueryable<NewsArticle>, IQueryable<NewsArticle>>? includes = null);

        Task<NewsArticle?> GetNewsArticleByIdAsync(string id,
            Func<IQueryable<NewsArticle>, IQueryable<NewsArticle>>? includes = null);

        Task CreateNewsArticleAsync(NewsArticle newsArticle, string? userId);

        Task UpdateNewsArticleAsync(NewsArticle newsArticle, string? userId);

        Task DeleteNewsArticleAsync(string id);

       
    }
}