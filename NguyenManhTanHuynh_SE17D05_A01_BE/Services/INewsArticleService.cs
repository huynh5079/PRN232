using DataLayer.Entities;

namespace NguyenManhTanHuynh_SE17D05_A01_BE.Services
{
    public interface INewsArticleService
    {
        Task<IEnumerable<NewsArticle>> GetAllAsync();
        Task<NewsArticle> GetByIdAsync(string id);
        Task CreateAsync(NewsArticle newsArticle, string userId);
        Task UpdateAsync(NewsArticle newsArticle, string userId);
        Task DeleteAsync(string id);
    }
}
