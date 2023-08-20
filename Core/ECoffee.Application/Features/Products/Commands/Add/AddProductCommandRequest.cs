using ECoffee.Application.Features.Products.DTOs;
using ECoffee.Application.Utilities.Results;
using MediatR;

namespace ECoffee.Application.Features.Products.Commands.Add
{
    public class AddProductCommandRequest : IRequest<IDataResult<ProductDTO>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int UnitsInStock { get; set; }
        public float Price { get; set; }
        public List<string> CategoryIds { get; set; }
    }
}
