using ECoffee.Application.Abstractions.Services;
using ECoffee.Application.Features.Orders.DTOs;
using ECoffee.Application.Utilities.Results;
using MediatR;

namespace ECoffee.Application.Features.Orders.Queries.GetById
{
    public class GetByIdOrderQueryHandler : IRequestHandler<GetByIdOrderQueryRequest, IDataResult<GetByIdOrderDTO>>
    {
        private IOrderService _orderService;

        public GetByIdOrderQueryHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IDataResult<GetByIdOrderDTO>> Handle(GetByIdOrderQueryRequest request, CancellationToken cancellationToken)
        {
            GetByIdOrderDTO getByIdOrderDTO=  await _orderService.GetByIdAsync(request.Id);
            return new SuccessDataResult<GetByIdOrderDTO>("Sipariş Getirildi", getByIdOrderDTO);
        }
    }
}
