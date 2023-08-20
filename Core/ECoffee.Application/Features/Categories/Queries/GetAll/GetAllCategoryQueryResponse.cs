using ECoffee.Application.Abstractions.DTO;
using ECoffee.Application.Features.Categories.DTOs;
using ECoffee.Application.Utilities.Results;
using MediatR;

namespace ECoffee.Application.Features.Categories.Queries.GetAll
{
    public class GetAllCategoryQueryResponse : IRequest<IDataResult<GetAllCategoriesDTO>>, IDTO
    {
        public List<GetAllCategoriesDTO> Categories { get; set; }
        public int TotalCategoryCount { get; set; }
    }
}

