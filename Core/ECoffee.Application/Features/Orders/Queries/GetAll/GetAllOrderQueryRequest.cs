using ECoffee.Application.Utilities.Results;
using MediatR;

namespace ECoffee.Application.Features.Orders.Queries.GetAll
{
    public class GetAllOrderQueryRequest : IRequest<IDataResult<GetAllOrderQueryResponse>>
    {
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
