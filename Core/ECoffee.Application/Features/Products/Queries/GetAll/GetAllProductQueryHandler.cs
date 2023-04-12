using ECoffee.Application.Abstractions.Services;
using ECoffee.Application.Features.Products.DTOs;
using ECoffee.Application.Utilities.Results;
using MediatR;

namespace ECoffee.Application.Features.Products.Queries.GetAll
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, IDataResult<GetAllProductQueryResponse>>
    {
        private IProductService _productService;

        public GetAllProductQueryHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IDataResult<GetAllProductQueryResponse>> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            (List<GetAllProductsDTO> products, int totalCount) data = await _productService.GetAllAsync(request.Page, request.Size);
            return new SuccessDataResult<GetAllProductQueryResponse>("Listelendi", new() { GetAllProductsDTOs = data.products, TotalCount = data.totalCount });
        }
    }
}
