namespace ECoffee.Application.Features.Orders.DTOs
{
    public class UpdateOrderDTO
    {
        public int Id { get; set; }
        public List<int> ProductId { get; set; }
        public bool IsActive { get; set; }
    }
}
