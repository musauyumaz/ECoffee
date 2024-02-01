using ECoffee.Application.Abstractions.Services;
using ECoffee.Application.Features.Orders.DTOs;
using ECoffee.Application.Utilities.Results;
using MediatR;

namespace ECoffee.Application.Features.Orders.Commands.Add
{
    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommandRequest, IDataResult<OrderDTO>>
    {
        private IOrderService _orderService;

        public AddOrderCommandHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IDataResult<OrderDTO>> Handle(AddOrderCommandRequest request, CancellationToken cancellationToken)
        {
            OrderDTO orderDTO = await _orderService.AddAsync(new());
            var data = new SuccessDataResult<OrderDTO>(" Sipariş Alındı", orderDTO);
            return data;
        }
    }
}
