using ECoffee.Application.Abstractions.Services;
using ECoffee.Application.Features.Customers.DTOs;
using ECoffee.Application.Features.Customers.Queries.GetAll;
using ECoffee.Application.Features.Orders.DTOs;
using ECoffee.Application.Utilities.Results;
using MediatR;

namespace ECoffee.Application.Features.Orders.Queries.GetAll
{
    public class GetAllOrderQueryHandler : IRequestHandler<GetAllOrderQueryRequest, IDataResult<GetAllOrderQueryResponse>>
    {
        private IOrderService _orderService;

        public GetAllOrderQueryHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IDataResult<GetAllOrderQueryResponse>> Handle(GetAllOrderQueryRequest request, CancellationToken cancellationToken)
        {
            (List<GetAllOrdersDTO> Orders, int TotalCount) data = await _orderService.GetAllAsync(request.Page, request.Size);
            return new SuccessDataResult<GetAllOrderQueryResponse>("Siparişler Listelendi", new() { GetAllOrders = data.Orders, TotalCount = data.TotalCount });
        }
    }
}
