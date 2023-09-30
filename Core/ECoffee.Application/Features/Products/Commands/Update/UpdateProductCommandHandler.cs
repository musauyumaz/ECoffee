using ECoffee.Application.Abstractions.Services;
using ECoffee.Application.Features.Products.DTOs;
using ECoffee.Application.Utilities.Results;
using MediatR;

namespace ECoffee.Application.Features.Products.Commands.Update
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, IDataResult<ProductDTO>>
    {
        private IProductService _productService;

        public UpdateProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IDataResult<ProductDTO>> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            ProductDTO productDTO = await _productService.UpdateAsync(new UpdateProductDTO() { Id = request.Id, Name = request.Name, Description = request.Description, Price = request.Price, UnitsInStock = request.UnitsInStock, CategoryIds = request.CategoryIds, IsActive = request.IsActive });
            return new SuccessDataResult<ProductDTO>("Ürün Güncellendi", productDTO);
        }
    }
}
