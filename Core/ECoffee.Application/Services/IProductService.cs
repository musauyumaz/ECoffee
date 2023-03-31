using ECoffee.Application.Features.Products.DTOs;

namespace ECoffee.Application.Services
{
    public interface IProductService
    {
        Task<List<GetAllProductsDTO>> GetAllAsync();
        Task<GetByIdProductDTO> GetByIdAsync(int id);
        Task<ProductDTO> AddAsync(AddProductDTO addProductDTO);
        Task<ProductDTO> UpdateAsync(UpdateProductDTO updateProductDTO);
        Task<ProductDTO> DeleteAsync(int id);
    }
}
