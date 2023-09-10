using ECoffee.Application.Features.Products.DTOs;
using ECoffee.Application.Utilities.Results;
using MediatR;

namespace ECoffee.Application.Features.Products.Commands.Update
{
    public class UpdateProductCommandRequest : IRequest<IDataResult<ProductDTO>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UnitsInStock { get; set; }
        public float Price { get; set; }
        public List<string> CategoryIds { get; set; }
        public bool IsActive { get; set; }
    }
}
