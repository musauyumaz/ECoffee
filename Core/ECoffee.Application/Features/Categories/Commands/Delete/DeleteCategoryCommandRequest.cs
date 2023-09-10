using ECoffee.Application.Features.Categories.DTOs;
using ECoffee.Application.Utilities.Results;
using MediatR;

namespace ECoffee.Application.Features.Categories.Commands.Delete
{
    public class DeleteCategoryCommandRequest : IRequest<IDataResult<CategoryDTO>>
    {
        public string Id { get; set; }
    }
}
