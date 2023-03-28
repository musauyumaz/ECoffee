namespace ECoffee.Application.Features.Products.DTOs
{
    public class AddProductDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int UnitsInStock { get; set; }
        public float Price { get; set; }
        public List<int> CategoryIds { get; set; }
    }
}
