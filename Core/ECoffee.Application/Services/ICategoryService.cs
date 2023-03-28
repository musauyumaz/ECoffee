using ECoffee.Application.Features.Categories.DTOs;

namespace ECoffee.Application.Services
{
    public interface ICategoryService
    {
        Task<List<GetAllCategoriesDTO>> GetAllAsync();
        Task<GetByIdCategoryDTO> GetByIdAsync(int id);
        Task<CategoryDTO> AddAsync(AddCategoryDTO addCategoryDTO);
        Task<CategoryDTO> UpdateAsync(UpdateCategoryDTO updateCategoryDTO);
        Task<CategoryDTO> DeleteAsync(int id);
    }
}
