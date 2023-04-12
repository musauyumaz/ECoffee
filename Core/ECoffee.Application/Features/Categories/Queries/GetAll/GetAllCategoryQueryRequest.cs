using ECoffee.Application.Utilities.Results;
using MediatR;

namespace ECoffee.Application.Features.Categories.Queries.GetAll
{
    public class GetAllCategoryQueryRequest : IRequest<IDataResult<GetAllCategoryQueryResponse>>
    {
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
