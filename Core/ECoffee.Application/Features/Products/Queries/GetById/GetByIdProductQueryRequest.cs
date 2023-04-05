using ECoffee.Application.Features.Products.DTOs;
using ECoffee.Application.Utilities.Results;
using MediatR;

namespace ECoffee.Application.Features.Products.Queries.GetById
{
    public class GetByIdProductQueryRequest : IRequest<IDataResult<GetByIdProductDTO>>
    {
        public int Id { get; set; }
    }
}
