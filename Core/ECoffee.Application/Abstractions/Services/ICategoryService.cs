using ECoffee.Application.Features.Categories.DTOs;
using ECoffee.Domain.Entities;

namespace ECoffee.Application.Abstractions.Services
{
    public interface ICategoryService
    {
        Task<(List<GetAllCategoriesDTO>, int totalCount)> GetAllAsync(int page,int size);
        Task<GetByIdCategoryDTO> GetByIdAsync(string id);
        Task<CategoryDTO> AddAsync(AddCategoryDTO addCategoryDTO);
        Task<CategoryDTO> UpdateAsync(UpdateCategoryDTO updateCategoryDTO);
        Task<CategoryDTO> DeleteAsync(string id);
        Task<List<Category>> GetAllCategoriesByIds(List<string> ids);
    }
}
