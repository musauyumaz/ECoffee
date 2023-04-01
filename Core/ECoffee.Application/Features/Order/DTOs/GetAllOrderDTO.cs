namespace ECoffee.Application.Features.Order.DTOs
{
    public class GetAllOrderDTO
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public List<string> ProductNames { get; set; }
    }
}
