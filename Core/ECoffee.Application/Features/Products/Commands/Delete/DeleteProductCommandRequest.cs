using ECoffee.Application.Features.Products.DTOs;
using ECoffee.Application.Utilities.Results;
using MediatR;

namespace ECoffee.Application.Features.Products.Commands.Delete
{
    public class DeleteProductCommandRequest : IRequest<IDataResult<ProductDTO>>
    {
        public int Id { get; set; }
    }
}
