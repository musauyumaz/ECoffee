using ECoffee.Application.Abstractions.Services;
using ECoffee.Application.Features.Categories.DTOs;
using ECoffee.Application.Utilities.Results;
using MediatR;

namespace ECoffee.Application.Features.Categories.Queries.GetById
{
    public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQueryRequest, IDataResult<GetByIdCategoryDTO>>
    {
        private ICategoryService _categoryService;

        public GetByIdCategoryQueryHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IDataResult<GetByIdCategoryDTO>> Handle(GetByIdCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            GetByIdCategoryDTO getByIdCategoryDTO = await _categoryService.GetByIdAsync(request.Id);
            return new SuccessDataResult<GetByIdCategoryDTO>("Kategori Getirildi", getByIdCategoryDTO);
        }

    }
}
