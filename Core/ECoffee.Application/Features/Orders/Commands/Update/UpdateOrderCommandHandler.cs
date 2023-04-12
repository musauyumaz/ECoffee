using ECoffee.Application.Abstractions.Services;
using ECoffee.Application.Features.Categories.DTOs;
using ECoffee.Application.Features.Orders.DTOs;
using ECoffee.Application.Utilities.Results;
using MediatR;

namespace ECoffee.Application.Features.Orders.Commands.Update
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommandRequest, IDataResult<OrderDTO>>
    {
        private IOrderService _orderService;

        public UpdateOrderCommandHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IDataResult<OrderDTO>> Handle(UpdateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            OrderDTO orderDTO = await _orderService.UpdateAsync(OrderConverter.UpdateOrderCommandRequestToUpdateOrderDTO(request));
            return new SuccessDataResult<OrderDTO>(" Sipariş Güncellendi", orderDTO);
        }
    }
}
