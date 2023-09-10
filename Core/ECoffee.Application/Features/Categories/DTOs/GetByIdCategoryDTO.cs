using ECoffee.Application.Abstractions.DTO;

namespace ECoffee.Application.Features.Categories.DTOs
{
    public class GetByIdCategoryDTO : IDTO
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public List<string> ProductNames { get; set; }
    }
}
