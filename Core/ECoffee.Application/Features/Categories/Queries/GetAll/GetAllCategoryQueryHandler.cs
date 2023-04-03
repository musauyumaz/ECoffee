using ECoffee.Application.Abstractions.Services;
using ECoffee.Application.Features.Categories.DTOs;
using ECoffee.Application.Utilities.Results;
using MediatR;

namespace ECoffee.Application.Features.Categories.Queries.GetAll
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQueryRequest, IDataResult<GetAllCategoryQueryResponse>>
    {
        private ICategoryService _categoryService;

        public GetAllCategoryQueryHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IDataResult<GetAllCategoryQueryResponse>> Handle(GetAllCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            (List<GetAllCategoriesDTO> categories, int totalCount) data = await _categoryService.GetAllAsync(request.Page, request.Size);
            return new SuccessDataResult<GetAllCategoryQueryResponse>("Data Listelendi",new GetAllCategoryQueryResponse() { Categories = data.categories, TotalCategoryCount = data.totalCount});
        }
    }
}
