using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using NguyenManhTanHuynh_SE17D05_A01_BE.Repositories;

namespace NguyenManhTanHuynh_SE17D05_A01_BE.Services
{
    public class NewsArticleService : INewsArticleService
    {
        private readonly IGenericRepository<NewsArticle> _newsArticleRepository;
        private readonly IGenericRepository<SystemAccount> _accountRepository;
        private readonly IGenericRepository<Category> _categoryRepository;

        public NewsArticleService(
            IGenericRepository<NewsArticle> newsArticleRepository,
            IGenericRepository<SystemAccount> accountRepository,
            IGenericRepository<Category> categoryRepository)
        {
            _newsArticleRepository = newsArticleRepository;
            _accountRepository = accountRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<NewsArticle>> GetAllAsync()
        {
            return await _newsArticleRepository.GetAllAsync(
                includes: q => q.Include(na => na.Category).Include(na => na.CreatedBy));
        }

        public async Task<NewsArticle> GetByIdAsync(string id)
        {
            return await _newsArticleRepository.GetAsync(
                na => na.Id == id,
                q => q.Include(na => na.Category).Include(na => na.CreatedBy));
        }

        public async Task CreateAsync(NewsArticle newsArticle, string userId)
        {
            var user = await _accountRepository.GetAsync(a => a.Id == userId);
            if (user == null)
                throw new Exception("User not found");

            var category = await _categoryRepository.GetAsync(c => c.Id == newsArticle.CategoryId);
            if (category == null)
                throw new Exception("Category not found");

            newsArticle.CreatedById = userId;
            newsArticle.CreatedDate = DateTime.UtcNow;

            await _newsArticleRepository.CreateAsync(newsArticle);
            await _newsArticleRepository.SaveAsync();
        }

        public async Task UpdateAsync(NewsArticle newsArticle, string userId)
        {
            var existingArticle = await _newsArticleRepository.GetAsync(na => na.Id == newsArticle.Id);
            if (existingArticle == null)
                throw new Exception("News article not found");

            var user = await _accountRepository.GetAsync(a => a.Id == userId);
            if (user == null)
                throw new Exception("User not found");

            var category = await _categoryRepository.GetAsync(c => c.Id == newsArticle.CategoryId);
            if (category == null)
                throw new Exception("Category not found");

            if (existingArticle.CreatedById != userId && user.AccountRole != 0) // Only Admin or creator can update
                throw new Exception("Unauthorized to update this article");

            existingArticle.NewsTitle = newsArticle.NewsTitle;
            existingArticle.NewsContent = newsArticle.NewsContent;
            existingArticle.NewsStatus = newsArticle.NewsStatus;
            existingArticle.CategoryId = newsArticle.CategoryId;
            existingArticle.UpdatedAt = DateTime.UtcNow;

            await _newsArticleRepository.UpdateAsync(existingArticle);
            await _newsArticleRepository.SaveAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var newsArticle = await _newsArticleRepository.GetAsync(na => na.Id == id);
            if (newsArticle == null)
                throw new Exception("News article not found");

            await _newsArticleRepository.RemoveAsync(newsArticle);
            await _newsArticleRepository.SaveAsync();
        }
    }
}
