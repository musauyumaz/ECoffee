using ECoffee.Application.Utilities.Results;
using MediatR;

namespace ECoffee.Application.Features.Customers.Queries.GetAll
{
    public class GetAllCustomerQueryRequest : IRequest<IDataResult<GetAllCustomerQueryResponse>>
    {
        public int Page { get; set; }
        public int Size { get; set; }

    }
}
