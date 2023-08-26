using ECoffee.Application.Abstractions.Repositories.Products;
using ECoffee.Application.Abstractions.Services;
using ECoffee.Application.Features.Products.DTOs;
using ECoffee.Domain.Entities;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;


namespace ECoffee.Persistence.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductCommandRepository _productCommandRepository;
        private readonly IProductQueryRepository _productQueryRepository;
        private readonly ICategoryService _categoryService;
        private readonly IDataProtector _dataProtector;

        public ProductService(IProductCommandRepository productCommandRepository, IProductQueryRepository productQueryRepository, ICategoryService categoryService, IDataProtectionProvider dataProtectionProvider)
        {
            _productCommandRepository = productCommandRepository;
            _productQueryRepository = productQueryRepository;
            _categoryService = categoryService;
            _dataProtector = dataProtectionProvider.CreateProtector("Product");
        }

        public async Task<ProductDTO> AddAsync(AddProductDTO addProductDTO)
        {
            Product product = await _productCommandRepository.AddAsync(new() { UnitsInStock = addProductDTO.UnitsInStock, Description = addProductDTO.Description, Name = addProductDTO.Name, Price = addProductDTO.Price });
            product.Categories = await _categoryService.GetAllCategoriesByIds(addProductDTO.CategoryIds);
            await _productCommandRepository.SaveAsync();
            return new() { Id = _dataProtector.Protect(product.Id.ToString()), Name = product.Name, Price = product.Price, Description = product.Description, UnitsInStock = product.UnitsInStock };
        }


        public async Task<ProductDTO> DeleteAsync(string id)
        {
            Product product = await _productCommandRepository.RemoveAsync(int.Parse(_dataProtector.Unprotect(id)));
            await _productCommandRepository.SaveAsync();
            return new() { Id = _dataProtector.Protect(product.Id.ToString()), Name = product.Name, Price = product.Price, Description = product.Description, UnitsInStock = product.UnitsInStock };
        }

        public async Task<(List<GetAllProductsDTO>, int totalCount)> GetAllAsync(int page, int size)
        {
            List<Product> products = await _productQueryRepository.GetAll().Skip(page * size).Take(size).Include(c => c.Categories).ToListAsync();
            return (products.Select(p => new GetAllProductsDTO
            {
                Id = _dataProtector.Unprotect( p.Id.ToString()),
                Name = p.Name,
                Description = p.Description,
                UnitsInStock = p.UnitsInStock,
                Price = p.Price,
                CategoryNames = p.Categories.Select(c => c.Name).ToList()
            }).ToList(), await _productQueryRepository.GetAll().CountAsync());
        }

        public async Task<List<Product>> GetAllProductsByIds(List<string> ids)
            => await _productQueryRepository.GetAll().Where(p => ids.Contains(_dataProtector.Unprotect(p.Id.ToString()))).ToListAsync();

        public async Task<GetByIdProductDTO> GetByIdAsync(string id)
        {
            Product product =await _productQueryRepository.GetByIdAsync(int.Parse(_dataProtector.Unprotect(id.ToString())));
            return new() { Id=_dataProtector.Protect(product.Id.ToString()), Name = product.Name, Description = product.Description, UnitsInStock = product.UnitsInStock, Price = product.Price, CategoryNames = product.Categories.Select(c => c.Name).ToList()};
        }
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
            return new() { Id = _dataProtector.Protect(product.Id.ToString()), Name = product.Name, Price = product.Price, Description = product.Description, UnitsInStock = product.UnitsInStock };
        }
    }
}
