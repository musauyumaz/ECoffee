using ECoffee.Application.Abstractions.Services;
using ECoffee.Application.Features.Categories.DTOs;
using ECoffee.Application.Utilities.Results;
using MediatR;

namespace ECoffee.Application.Features.Categories.Commands.Update
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, IDataResult<CategoryDTO>>
    {
        private ICategoryService _categoryService;

        public UpdateCategoryCommandHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IDataResult<CategoryDTO>> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            CategoryDTO categoryDTO = await _categoryService.UpdateAsync(new() { Id = request.Id.ToString(), Name = request.Name, Description = request.Description, IsActive = request.IsActive });
            return new SuccessDataResult<CategoryDTO>(categoryDTO.Name + " Kategori Güncellendi", categoryDTO);
        }
    }

}
