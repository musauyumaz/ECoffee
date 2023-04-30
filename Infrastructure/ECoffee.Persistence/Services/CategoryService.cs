using ECoffee.Application.Abstractions.Repositories.Categories;
using ECoffee.Application.Abstractions.Services;
using ECoffee.Application.Features.Categories.DTOs;
using ECoffee.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECoffee.Persistence.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryCommandRepository _categoryCommandRepository;
        private readonly ICategoryQueryRepository _categoryQueryRepository;

        public CategoryService(ICategoryCommandRepository categoryCommandRepository, ICategoryQueryRepository categoryQueryRepository)
        {
            _categoryCommandRepository = categoryCommandRepository;
            _categoryQueryRepository = categoryQueryRepository;
        }

        public async Task<CategoryDTO> AddAsync(AddCategoryDTO addCategoryDTO)
        {
            Category category = await _categoryCommandRepository.AddAsync(CategoryConverter.AddCategoryDTOToCategory(addCategoryDTO));
            await _categoryCommandRepository.SaveAsync();
            return CategoryConverter.CategoryToCategoryDTO(category);
        }

        public async Task<CategoryDTO> DeleteAsync(int id)
        {
            Category category = await _categoryCommandRepository.RemoveAsync(id);
            await _categoryCommandRepository.SaveAsync();
            return CategoryConverter.CategoryToCategoryDTO(category);
        }

        public async Task<(List<GetAllCategoriesDTO>, int totalCount)> GetAllAsync(int page, int size)
            => (CategoryConverter.CategoryListToGetAllCategoriesDTO(await _categoryQueryRepository.GetAll().Where(c => c.IsActive == true).Include(c => c.Products).Skip(page * size).Take(size).ToListAsync()), await _categoryQueryRepository.GetAll().CountAsync());

        public async Task<List<Category>> GetAllCategoriesByIds(List<int> ids)
            => await _categoryQueryRepository.GetAll().Where(c => ids.Contains(c.Id)).ToListAsync();


        public async Task<GetByIdCategoryDTO> GetByIdAsync(int id)
            => CategoryConverter.CategoryToGetByIdCategoryDTO(await _categoryQueryRepository.Table.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == id));


        public async Task<CategoryDTO> UpdateAsync(UpdateCategoryDTO updateCategoryDTO)
        {
            Category category =await _categoryQueryRepository.GetByIdAsync(updateCategoryDTO.Id);
            category.Description = updateCategoryDTO.Description;
            category.Name=updateCategoryDTO.Name;
            category.IsActive= updateCategoryDTO.IsActive;
            _categoryCommandRepository.Update(category);
            await _categoryCommandRepository.SaveAsync();
            return CategoryConverter.CategoryToCategoryDTO(category);
        }
    }
}
