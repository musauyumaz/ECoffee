using ECoffee.Application.Abstractions.DTO;
using ECoffee.Application.Features.Customers.DTOs;

namespace ECoffee.Application.Features.Customers.Queries.GetAll
{
    public class GetAllCustomerQueryResponse: IDTO
    {
        public List<GetAllCustomersDTO> GetAllCustomersDTOs{ get; set; }
        public int TotalCount { get; set; }
    }
}
