using ECoffee.Application.Features.Orders.DTOs;
using ECoffee.Application.Utilities.Results;
using MediatR;

namespace ECoffee.Application.Features.Orders.Queries.GetById
{
    public class GetByIdOrderQueryRequest : IRequest<IDataResult<GetByIdOrderDTO>>
    {
        public string Id { get; set; }
    }
}
