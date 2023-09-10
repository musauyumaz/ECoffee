//using ECoffee.Application.Features.Products.Commands.Add;
//using ECoffee.Application.Features.Products.Commands.Update;
//using ECoffee.Domain.Entities;

//namespace ECoffee.Application.Features.Products.DTOs
//{
//    public static class ProductConverter
//    {

//        public static ProductDTO ProductToProductDTO(Product product)
//            => new() { Id = product.Id, Name = product.Name, Price = product.Price, Description = product.Description, UnitsInStock = product.UnitsInStock };

//        public static Product AddProductDTOToProduct(AddProductDTO addProductDTO)
//            => new() { UnitsInStock = addProductDTO.UnitsInStock, Description = addProductDTO.Description, Name = addProductDTO.Name, Price = addProductDTO.Price };
 
//        public static GetByIdProductDTO ProductToGetByIdProductDTO(Product product)
//            => new() { Id = product.Id, Name = product.Name, Description = product.Description, UnitsInStock = product.UnitsInStock, Price = product.Price, CategoryNames = product.Categories.Select(c => c.Name).ToList() };

//        public static List<GetAllProductsDTO> ProductListToGetAllProductsDTO(List<Product> products)
//            => products.Select(p => new GetAllProductsDTO
//            {
//                Id = p.Id,
//                Name = p.Name,
//                Description = p.Description,
//                UnitsInStock = p.UnitsInStock,
//                Price = p.Price,
//                CategoryNames = p.Categories.Select(c => c.Name).ToList()
//            }).ToList();

//        public static AddProductDTO AddProductCommandRequestToAddProductDTO(AddProductCommandRequest addProductCommandRequest)
//            => new() { Name = addProductCommandRequest.Name, Description = addProductCommandRequest.Description, Price = addProductCommandRequest.Price, UnitsInStock = addProductCommandRequest.UnitsInStock, CategoryIds = addProductCommandRequest.CategoryIds };

//        public static UpdateProductDTO UpdateProductCommandRequestToUpdateProductDTO(UpdateProductCommandRequest updateProductCommandRequest)
//        => new() { Id = updateProductCommandRequest.Id, Name = updateProductCommandRequest.Name, Description = updateProductCommandRequest.Description, Price = updateProductCommandRequest.Price, UnitsInStock = updateProductCommandRequest.UnitsInStock, CategoryIds = updateProductCommandRequest.CategoryIds, IsActive = updateProductCommandRequest.IsActive };
//    }
//}
