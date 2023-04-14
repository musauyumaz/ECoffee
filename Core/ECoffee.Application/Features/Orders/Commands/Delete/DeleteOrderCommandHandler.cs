using ECoffee.Application.Abstractions.Services;
using ECoffee.Application.Features.Categories.DTOs;
using ECoffee.Application.Features.Orders.DTOs;
using ECoffee.Application.Utilities.Results;
using MediatR;

namespace ECoffee.Application.Features.Orders.Commands.Delete
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommandRequest, IDataResult<OrderDTO>>
    {
        private IOrderService _orderService;

        public DeleteOrderCommandHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IDataResult<OrderDTO>> Handle(DeleteOrderCommandRequest request, CancellationToken cancellationToken)
        {
            OrderDTO orderDTO = await _orderService.DeleteAsync(request.Id);
            return new SuccessDataResult<OrderDTO>(" Sipariş Silindi.", orderDTO);
        }
    }
}
