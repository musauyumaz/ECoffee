using ECoffee.Application.Repositories.Categories;
using ECoffee.Domain.Entities;
using ECoffee.Persistence.Contexts;

namespace ECoffee.Persistence.Repositories.Categories
{
    public class CategoryCommandRepository : CommandRepository<Category>, ICategoryCommandRepository
    {
        public CategoryCommandRepository(ECoffeeDbContext eCoffeeDbContext) : base(eCoffeeDbContext) {}
    }
}
