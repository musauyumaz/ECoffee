using ECoffee.Application.Abstractions.Repositories.Products;
using ECoffee.Application.Abstractions.Services;
using ECoffee.Application.Features.Products.DTOs;
using ECoffee.Domain.Entities;

using Microsoft.EntityFrameworkCore;


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
            Product product = await _productCommandRepository.AddAsync(ProductConverter.AddProductDTOToProduct(addProductDTO));
            product.Categories = await _categoryService.GetAllCategoriesByIds(addProductDTO.CategoryIds);
            await _productCommandRepository.SaveAsync();
            return ProductConverter.ProductToProductDTO(product);
        }


        public async Task<ProductDTO> DeleteAsync(int id)
        {
            Product product = await _productCommandRepository.RemoveAsync(id);
            await _productCommandRepository.SaveAsync();
            return new() { Id = product.Id, Name = product.Name, Description = product.Description, Price = product.Price, UnitsInStock = product.UnitsInStock };
        }

        public async Task<List<GetAllProductsDTO>> GetAllAsync()
        {
            List<Product> products = await _productQueryRepository.GetAll().Include(c => c.Categories).ToListAsync();
            return ProductConverter.ProductListToGetAllProductsDTO(products);
        }

        public async Task<GetByIdProductDTO> GetByIdAsync(int id)
        => ProductConverter.ProductToGetByIdProductDTO(await _productQueryRepository.GetByIdAsync(id));

        public async Task<ProductDTO> UpdateAsync(UpdateProductDTO updateProductDTO)
        {
            Product product = ProductConverter.UpdateProductDTOToProduct(updateProductDTO);
            _productCommandRepository.Update(product);
            await _productCommandRepository.SaveAsync();
            return ProductConverter.ProductToProductDTO(product);
        }
    }
}
