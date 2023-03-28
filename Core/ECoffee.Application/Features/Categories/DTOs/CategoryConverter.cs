using ECoffee.Domain.Entities;

namespace ECoffee.Application.Features.Categories.DTOs
{
    public static class CategoryConverter
    {
        public static Category AddCategoryDTOToCategory(AddCategoryDTO addCategoryDTO)
            => new() { Name = addCategoryDTO.Name, Description = addCategoryDTO.Description };


        public static Category UpdateCategoryDTOToCategory(UpdateCategoryDTO updateCategoryDTO)
            => new() { Id = updateCategoryDTO.Id, IsActive = updateCategoryDTO.IsActive, Name = updateCategoryDTO.Name, Description = updateCategoryDTO.Description };


        public static CategoryDTO CategoryToCategoryDTO(Category category)
            => new() { Id = category.Id, Description = category.Description, Name = category.Name };

        public static GetByIdCategoryDTO CategoryToGetByIdCategoryDTO(Category category)
            => new() { Id = category.Id, Description = category.Description, Name = category.Name,ProductNames = category.Products.Select(p=>p.Name).ToList() };


        public static List<GetAllCategoriesDTO> CategoryListToGetAllCategoriesDTO(List<Category> categories)
            => categories.Select(c => new GetAllCategoriesDTO() { Id = c.Id, Name = c.Name, Description = c.Description, ProductNames = c.Products.Select(p => p.Name).ToList() }).ToList();



    }
}
