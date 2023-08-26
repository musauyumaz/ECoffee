using ECoffee.Application.Abstractions.DTO;

namespace ECoffee.Application.Features.Orders.DTOs
{
    public class GetByIdOrderDTO : IDTO
    {
        public string Id { get; set; }
        public string CustomerName { get; set; }
        public List<string> ProductNames { get; set; }
    }
}
