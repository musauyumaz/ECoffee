using ECoffee.Application.Utilities.Results;
using MediatR;

namespace ECoffee.Application.Features.Products.Queries.GetAll
{
    public class GetAllProductQueryRequest : IRequest<IDataResult<GetAllProductQueryResponse>>
    {
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
