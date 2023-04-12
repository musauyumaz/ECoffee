using ECoffee.Application.Features.Orders.DTOs;
using ECoffee.Application.Utilities.Results;
using MediatR;

namespace ECoffee.Application.Features.Orders.Commands.Update
{
    public class UpdateOrderCommandRequest: IRequest<IDataResult<OrderDTO>>
    {
        public int Id { get; set; }
        public List<int> ProductIds { get; set; }
        public string Note { get; set; }
        public bool IsActive { get; set; }
    }
}
