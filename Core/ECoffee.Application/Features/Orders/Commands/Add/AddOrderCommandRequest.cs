using ECoffee.Application.Features.Orders.DTOs;
using ECoffee.Application.Utilities.Results;
using MediatR;

namespace ECoffee.Application.Features.Orders.Commands.Add
{
    public class AddOrderCommandRequest : IRequest<IDataResult<OrderDTO>>
    {
        public int CustomerId { get; set; }
        public List<string> ProductIds { get; set; }
        public string Note { get; set; }
    }
}
