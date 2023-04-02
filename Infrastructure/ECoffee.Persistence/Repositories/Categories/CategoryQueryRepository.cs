using ECoffee.Application.Abstractions.Repositories.Categories;
using ECoffee.Domain.Entities;
using ECoffee.Persistence.Contexts;

namespace ECoffee.Persistence.Repositories.Categories
{
    public class CategoryQueryRepository : QueryRepository<Category>, ICategoryQueryRepository
    {
        public CategoryQueryRepository(ECoffeeDbContext eCoffeeDbContext) : base(eCoffeeDbContext){}
    }
}
