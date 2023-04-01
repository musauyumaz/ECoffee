namespace ECoffee.Application.Features.Order.DTOs
{
    public class UpdateOrderDTO
    {
        public int Id { get; set; }
        public List<int> ProductId { get; set; }
        public bool IsActive { get; set; }
    }
}
