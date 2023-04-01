namespace ECoffee.Application.Features.Order.DTOs
{
    public class AddOrderDTO
    {
        public int CustomerId { get; set; }
        public List<int> ProductId { get; set; }
        public string Note { get; set; }
    }
}
