using ECoffee.Application.Abstractions.DTO;
using ECoffee.Application.Features.Orders.DTOs;
using ECoffee.Application.Utilities.Results;
using MediatR;

namespace ECoffee.Application.Features.Orders.Queries.GetAll
{
    public class GetAllOrderQueryResponse : IRequest<IDataResult<GetAllOrdersDTO>>, IDTO
    {
        public List<GetAllOrdersDTO> GetAllOrders { get; set; }
        public int TotalCount { get; set; }
    }
}
