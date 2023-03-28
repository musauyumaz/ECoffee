namespace ECoffee.Application.Features.Categories.DTOs
{
    public class GetAllCategoriesDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<string>? ProductNames { get; set; }
    }
}
