using ECoffee.Application.Abstractions.Services;
using ECoffee.Application.Features.Categories.DTOs;
using ECoffee.Application.Utilities.Results;
using MediatR;

namespace ECoffee.Application.Features.Categories.Commands.Add
{
    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommandRequest, IDataResult<CategoryDTO>>
    {
        private ICategoryService _categoryService;
        public AddCategoryCommandHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IDataResult<CategoryDTO>> Handle(AddCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            CategoryDTO categoryDTO = await _categoryService.AddAsync(CategoryConverter.AddCategoryCommandRequestToAddCategoryDTO(request));
            var data = new SuccessDataResult<CategoryDTO>(categoryDTO.Name + " Kategori Eklendi", categoryDTO);
            return data;
        }
    }

}
