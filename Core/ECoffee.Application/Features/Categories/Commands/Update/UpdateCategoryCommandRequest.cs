using ECoffee.Application.Features.Categories.DTOs;
using ECoffee.Application.Utilities.Results;
using MediatR;

namespace ECoffee.Application.Features.Categories.Commands.Update
{
    public class UpdateCategoryCommandRequest : IRequest<IDataResult<CategoryDTO>>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }

}
