using ECoffee.Application.Features.Categories.DTOs;
using ECoffee.Application.Utilities.Results;
using MediatR;

namespace ECoffee.Application.Features.Categories.Queries.GetById
{
    public class GetByIdCategoryQueryRequest : IRequest<IDataResult<GetByIdCategoryDTO>>
    {
        public int Id { get; set; }
    }
}
