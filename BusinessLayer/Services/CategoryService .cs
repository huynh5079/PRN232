using DataLayer.Entities;
using BusinessLayer.Repositories;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Category> _categoryRepository;
        private readonly IGenericRepository<NewsArticle> _newsArticleRepository;

        public CategoryService(
            IGenericRepository<Category> categoryRepository,
            IGenericRepository<NewsArticle> newsArticleRepository)
        {
            _categoryRepository = categoryRepository;
            _newsArticleRepository = newsArticleRepository;
        }

        private async Task<bool> IsCategoryNameUnique(string categoryName, string? excludeId = null)
        {
            var existingCategory = await _categoryRepository.GetAsync(c => c.CategoryName == categoryName);
            return existingCategory == null || (existingCategory.Id == excludeId);
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(Expression<Func<Category, bool>>? filter = null)
        {
            return await _categoryRepository.GetAllAsync(filter);
        }

        public async Task<Category?> GetCategoryByIdAsync(string id)
        {
            return await _categoryRepository.GetAsync(c => c.Id == id);
        }

        public async Task CreateCategoryAsync(Category category) 
        {
            if (!await IsCategoryNameUnique(category.CategoryName))
            {
                throw new Exception("Category with this name already exists.");
            }

            // Category.IsActive is set by DTO, or defaulted in DTO
            await _categoryRepository.CreateAsync(category);
            await _categoryRepository.SaveAsync();
        }

        public async Task UpdateCategoryAsync(Category category) // (mapped from DTO)
        {
            var existingCategory = await _categoryRepository.GetAsync(c => c.Id == category.Id);
            if (existingCategory == null)
            {
                throw new Exception("Category not found.");
            }

            if (existingCategory.CategoryName != category.CategoryName && !await IsCategoryNameUnique(category.CategoryName, category.Id))
            {
                throw new Exception("Another category with this name already exists.");
            }

            existingCategory.CategoryName = category.CategoryName;
            existingCategory.CategoryDescription = category.CategoryDescription;
            existingCategory.IsActive = category.IsActive; 
            existingCategory.UpdatedAt = DateTime.UtcNow;

            await _categoryRepository.UpdateAsync(existingCategory);
            await _categoryRepository.SaveAsync();
        }

        public async Task DeleteCategoryAsync(string id)
        {
            var category = await _categoryRepository.GetAsync(c => c.Id == id);
            if (category == null)
            {
                throw new Exception("Category not found.");
            }

            // cannot delete if category is linked to any news articles
            var hasNewsArticles = await _newsArticleRepository.GetAllAsync(na => na.CategoryId == id);
            if (hasNewsArticles.Any())
            {
                throw new Exception("Cannot delete category with associated news articles.");
            }

            await _categoryRepository.RemoveAsync(category);
            await _categoryRepository.SaveAsync();
        }

    }
}