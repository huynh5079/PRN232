using DataLayer.Entities;
using BusinessLayer.Repositories;
using System.Linq.Expressions;

namespace BusinessLayer.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync(
            Expression<Func<Category, bool>>? filter = null);

        Task<Category?> GetCategoryByIdAsync(string id);

        Task CreateCategoryAsync(Category category);

        Task UpdateCategoryAsync(Category category);

        Task DeleteCategoryAsync(string id);

    }
}