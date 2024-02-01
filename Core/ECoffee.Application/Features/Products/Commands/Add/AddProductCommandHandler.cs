using ECoffee.Application.Abstractions.Services;
using ECoffee.Application.Features.Products.DTOs;
using ECoffee.Application.Utilities.Results;
using MediatR;

namespace ECoffee.Application.Features.Products.Commands.Add
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommandRequest, IDataResult<ProductDTO>>
    {
        private IProductService _productService;

        public AddProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IDataResult<ProductDTO>> Handle(AddProductCommandRequest request, CancellationToken cancellationToken)
        {
            ProductDTO productDTO = await _productService.AddAsync(new AddProductDTO() { Name = request.Name, Description = request.Description, Price = request.Price, UnitsInStock = request.UnitsInStock, CategoryIds = request.CategoryIds });
            return new SuccessDataResult<ProductDTO>("Ürün Eklendi", productDTO);
        }

    }
}
