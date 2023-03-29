using ECoffee.Application.Features.Products.DTOs;
using ECoffee.Application.Repositories.Products;
using ECoffee.Application.Services;
using ECoffee.Domain.Entities;

namespace ECoffee.Persistence.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductCommandRepository _productCommandRepository;
        private readonly IProductQueryRepository _productQueryRepository;
        private readonly ICategoryService _categoryService;

        public ProductService(IProductCommandRepository productCommandRepository, IProductQueryRepository productQueryRepository, ICategoryService categoryService)
        {
            _productCommandRepository = productCommandRepository;
            _productQueryRepository = productQueryRepository;
            _categoryService = categoryService;
        }

        public async Task<ProductDTO> AddAsync(AddProductDTO addProductDTO)
        {
            Product product = await _productCommandRepository.AddAsync(new() { Name = addProductDTO.Name, Price = addProductDTO.Price, UnitsInStock = addProductDTO.UnitsInStock, Description = addProductDTO.Description});
            product.Categories = await _categoryService.GetAllCategoriesByIds(addProductDTO.CategoryIds);
            await _productCommandRepository.SaveAsync();
            return new() { Id = product.Id, Name = product.Name, Description = product.Description, Price = product.Price, UnitsInStock = product.UnitsInStock };

        }

        public Task<ProductDTO> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<GetAllProductsDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProductDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDTO> UpdateAsync(UpdateProductDTO updateProductDTO)
        {
            throw new NotImplementedException();
        }
    }
}
