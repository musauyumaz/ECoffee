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

        public async Task<(List<GetAllProductsDTO>, int totalCount)> GetAllAsync(int page, int size)
        {
            List<Product> products = await _productQueryRepository.GetAll().Skip(page * size).Take(size).Include(c => c.Categories).ToListAsync();
            return (ProductConverter.ProductListToGetAllProductsDTO(products), await _productQueryRepository.GetAll().CountAsync());
        }

        public async Task<List<Product>> GetAllProductsByIds(List<int> ids)
            => await _productQueryRepository.GetAll().Where(p => ids.Contains(p.Id)).ToListAsync();

        public async Task<GetByIdProductDTO> GetByIdAsync(int id)
        => ProductConverter.ProductToGetByIdProductDTO(await _productQueryRepository.Table.Include(p => p.Categories).FirstOrDefaultAsync(p => p.Id == id));

        public async Task<ProductDTO> UpdateAsync(UpdateProductDTO updateProductDTO)
        {
            Product product = await _productQueryRepository.GetByIdAsync(updateProductDTO.Id);
            product.Categories = await _categoryService.GetAllCategoriesByIds(updateProductDTO.CategoryIds);
            product.Name=updateProductDTO.Name;
            product.Description=updateProductDTO.Description;
            product.UnitsInStock= updateProductDTO.UnitsInStock;
            product.Price=updateProductDTO.Price;
            product.IsActive= updateProductDTO.IsActive;


            _productCommandRepository.Update(product);
            await _productCommandRepository.SaveAsync();
            return ProductConverter.ProductToProductDTO(product);
        }
    }
}
