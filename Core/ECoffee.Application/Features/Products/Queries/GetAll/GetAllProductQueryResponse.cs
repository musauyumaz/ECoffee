using ECoffee.Application.Abstractions.DTO;
using ECoffee.Application.Features.Products.DTOs;

namespace ECoffee.Application.Features.Products.Queries.GetAll
{
    public class GetAllProductQueryResponse : IDTO
    {
        public List<GetAllProductsDTO> GetAllProductsDTOs { get; set; }
        public int TotalCount { get; set; }
    }
}
