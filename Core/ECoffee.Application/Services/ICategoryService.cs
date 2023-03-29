using ECoffee.Application.Features.Categories.DTOs;
using ECoffee.Domain.Entities;

namespace ECoffee.Application.Services
{
    public interface ICategoryService
    {
        Task<List<GetAllCategoriesDTO>> GetAllAsync();
        Task<GetByIdCategoryDTO> GetByIdAsync(int id);
        Task<CategoryDTO> AddAsync(AddCategoryDTO addCategoryDTO);
        Task<CategoryDTO> UpdateAsync(UpdateCategoryDTO updateCategoryDTO);
        Task<CategoryDTO> DeleteAsync(int id);
        Task<List<Category>> GetAllCategoriesByIds(List<int> ids);
    }
}
