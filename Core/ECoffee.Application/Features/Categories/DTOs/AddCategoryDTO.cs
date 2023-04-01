using ECoffee.Application.Abstractions.DTO;

namespace ECoffee.Application.Features.Categories.DTOs
{
    public class AddCategoryDTO : IDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
