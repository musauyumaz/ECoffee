using ECoffee.Application.Features.Orders.DTOs;
using ECoffee.Application.Utilities.Results;
using MediatR;

namespace ECoffee.Application.Features.Orders.Commands.Delete
{
    public class DeleteOrderCommandRequest:IRequest<IDataResult<OrderDTO>>
    {
        public int Id { get; set; }
    }
}
