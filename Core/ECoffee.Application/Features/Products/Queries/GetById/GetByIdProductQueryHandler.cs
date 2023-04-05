using ECoffee.Application.Abstractions.Services;
using ECoffee.Application.Features.Products.DTOs;
using ECoffee.Application.Utilities.Results;
using MediatR;

namespace ECoffee.Application.Features.Products.Queries.GetById
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest, IDataResult<GetByIdProductDTO>>
    {
        private IProductService _productService;

        public GetByIdProductQueryHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IDataResult<GetByIdProductDTO>> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
        {
            GetByIdProductDTO getByIdProductDTO = await _productService.GetByIdAsync(request.Id);
            return new SuccessDataResult<GetByIdProductDTO>("Ürün Getirildi", getByIdProductDTO);
        }
    }
}
