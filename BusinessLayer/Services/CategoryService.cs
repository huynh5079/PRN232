using AutoMapper;
using BusinessLayer.Repositories;
using DataLayer.DTOs;
using DataLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Categories> _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(IGenericRepository<Categories> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        public async Task<CategoryDto?> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryRepository.GetAsync(c => c.CategoryId == id);
            return _mapper.Map<CategoryDto?>(category);
        }

        public async Task<CategoryDto> CreateCategoryAsync(CategoryCreateDto categoryDto)
        {
            var categoryEntity = _mapper.Map<Categories>(categoryDto);
            await _categoryRepository.CreateAsync(categoryEntity);
            await _categoryRepository.SaveAsync();
            return _mapper.Map<CategoryDto>(categoryEntity);
        }

        public async Task UpdateCategoryAsync(int id, CategoryUpdateDto categoryDto)
        {
            var existingCategory = await _categoryRepository.GetAsync(c => c.CategoryId == id);
            if (existingCategory != null)
            {
                _mapper.Map(categoryDto, existingCategory);
                await _categoryRepository.UpdateAsync(existingCategory);
                await _categoryRepository.SaveAsync();
            }
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _categoryRepository.GetAsync(c => c.CategoryId == id);
            if (category != null)
            {
                await _categoryRepository.RemoveAsync(category);
                await _categoryRepository.SaveAsync();
            }
        }
    }
}