using ECoffee.Application.Abstractions.Repositories.Categories;
using ECoffee.Application.Abstractions.Services;
using ECoffee.Application.Features.Categories.DTOs;
using ECoffee.Domain.Entities;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;

namespace ECoffee.Persistence.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryCommandRepository _categoryCommandRepository;
        private readonly ICategoryQueryRepository _categoryQueryRepository;
        private readonly IDataProtector _dataProtector;

        public CategoryService(ICategoryCommandRepository categoryCommandRepository, ICategoryQueryRepository categoryQueryRepository, IDataProtectionProvider dataProtectionProvider)
        {
            _categoryCommandRepository = categoryCommandRepository;
            _categoryQueryRepository = categoryQueryRepository;
            _dataProtector = dataProtectionProvider.CreateProtector("categories");
        }

        public async Task<CategoryDTO> AddAsync(AddCategoryDTO addCategoryDTO)
        {
            Category category = await _categoryCommandRepository.AddAsync(new() { Name = addCategoryDTO.Name, Description = addCategoryDTO.Description });
            await _categoryCommandRepository.SaveAsync();
            return new() { Id = _dataProtector.Protect(category.Id.ToString()), Name = category.Name, Description = category.Description };
        }

        public async Task<CategoryDTO> DeleteAsync(string id)
        {
            Category category = await _categoryCommandRepository.RemoveAsync(int.Parse(_dataProtector.Unprotect(id.ToString())));
            await _categoryCommandRepository.SaveAsync();
            return new() { Id = _dataProtector.Protect(category.Id.ToString()), Name = category.Name, Description = category.Description };
        }

        public async Task<(List<GetAllCategoriesDTO>, int totalCount)> GetAllAsync(int page, int size)
            => (await _categoryQueryRepository.GetAll().Where(c => c.IsActive == true).Include(c => c.Products).Skip(page * size).Take(size).Select(c => new GetAllCategoriesDTO
            {
                Id = _dataProtector.Protect(c.Id.ToString()),
                Name = c.Name,
                Description = c.Description,
                ProductNames = c.Products.Select(p => p.Name).ToList()
            }).ToListAsync(), await _categoryQueryRepository.GetAll().CountAsync());

        public async Task<List<Category>> GetAllCategoriesByIds(List<string> ids)
            => await _categoryQueryRepository.GetAll().Where(c => ids.Contains(_dataProtector.Protect(c.Id.ToString()))).ToListAsync();

        public async Task<GetByIdCategoryDTO> GetByIdAsync(string id)
        {
            Category category = await _categoryQueryRepository.Table.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == int.Parse(_dataProtector.Unprotect(id)));
            return new() { Id = _dataProtector.Protect(category.Id.ToString()), Name = category.Name, Description = category.Description };
        }

        public async Task<CategoryDTO> UpdateAsync(UpdateCategoryDTO updateCategoryDTO)
        {
            Category category = await _categoryQueryRepository.GetByIdAsync(int.Parse(_dataProtector.Unprotect(updateCategoryDTO.Id)));
            category.Description = updateCategoryDTO.Description;
            category.Name = updateCategoryDTO.Name;
            category.IsActive = updateCategoryDTO.IsActive;
            _categoryCommandRepository.Update(category);
            await _categoryCommandRepository.SaveAsync();
            return new() { Id = _dataProtector.Protect(category.Id.ToString()), Name = category.Name, Description = category.Description };
        }
    }
}
