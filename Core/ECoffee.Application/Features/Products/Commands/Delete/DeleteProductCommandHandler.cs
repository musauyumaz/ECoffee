using ECoffee.Application.Abstractions.Services;
using ECoffee.Application.Features.Products.DTOs;
using ECoffee.Application.Utilities.Results;
using MediatR;

namespace ECoffee.Application.Features.Products.Commands.Delete
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, IDataResult<ProductDTO>>
    {
        private IProductService _productService;

        public DeleteProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IDataResult<ProductDTO>> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            ProductDTO productDTO = await _productService.DeleteAsync(request.Id);
            return new SuccessDataResult<ProductDTO>("Ürün silindi", productDTO);
        }
    }
}
