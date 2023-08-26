using ECoffee.Application.Features.Products.DTOs;
using ECoffee.Domain.Entities;

namespace ECoffee.Application.Abstractions.Services
{
    public interface IProductService
    {
        Task<(List<GetAllProductsDTO>, int totalCount)> GetAllAsync(int page, int size);
        Task<GetByIdProductDTO> GetByIdAsync(string id);
        Task<ProductDTO> AddAsync(AddProductDTO addProductDTO);
        Task<ProductDTO> UpdateAsync(UpdateProductDTO updateProductDTO);
        Task<ProductDTO> DeleteAsync(string id);
        Task<List<Product>> GetAllProductsByIds(List<string> ids);
    }
}
