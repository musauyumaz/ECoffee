using ECoffee.Application.Features.Products.DTOs;

namespace ECoffee.Application.Services
{
    public interface IProductService
    {
        Task<List<GetAllProductsDTO>> GetAllAsync();
        Task<GetByIdProductDTO> GetByIdAsync(int id);
        Task<GetByIdProductDTO> AddAsync(AddProductDTO addProductDTO);
        Task<GetByIdProductDTO> UpdateAsync(UpdateProductDTO updateProductDTO);
        Task<GetByIdProductDTO> DeleteAsync(int id);
    }
}
