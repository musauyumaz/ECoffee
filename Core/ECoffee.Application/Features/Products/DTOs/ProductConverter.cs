using ECoffee.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECoffee.Application.Features.Products.DTOs
{
    public static class ProductConverter
    {
        public static ProductDTO ProductToProductDTO(Product product)
            => new() { Name=product.Name, Price=product.Price,Description=product.Description,UnitsInStock=product.UnitsInStock};
        public static Product AddProductDTOToProduct(AddProductDTO addProductDTO)
            => new() { UnitsInStock = addProductDTO.UnitsInStock, Description = addProductDTO.Description, Name = addProductDTO.Name, Price = addProductDTO.Price };
        public static Product UpdateProductDTOToProduct(UpdateProductDTO updateProductDTO)
            => new() {Name = updateProductDTO.Name,Description = updateProductDTO.Description, Price = updateProductDTO.Price,UnitsInStock=updateProductDTO.UnitsInStock,IsActive=updateProductDTO.IsActive};
        public static GetByIdProductDTO ProductToGetByIdProductDTO(Product product)
            => new() { Id=product.Id,Name=product.Name,Description=product.Description,UnitsInStock=product.UnitsInStock,Price=product.Price,CategoryNames=product.Categories.Select(c=>c.Name).ToList()};

        public static List<GetAllProductsDTO> ProductListToGetAllProductsDTO(List<Product> products)
            =>products.Select(p => new GetAllProductsDTO
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                UnitsInStock = p.UnitsInStock,
                Price = p.Price,
                CategoryNames = p.Categories.Select(c => c.Name).ToList()
            }).ToList();

    }
}
