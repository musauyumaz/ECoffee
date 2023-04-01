using ECoffee.Application.Features.Categories.DTOs;
using ECoffee.Application.Utilities.Results;
using MediatR;

namespace ECoffee.Application.Features.Categories.Commands.Add
{
    public class AddCategoryCommandRequest : IRequest<IDataResult<CategoryDTO>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

}
