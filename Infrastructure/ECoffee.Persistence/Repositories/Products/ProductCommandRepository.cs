using ECoffee.Application.Repositories.Categories;
using ECoffee.Application.Repositories.Products;
using ECoffee.Domain.Entities;
using ECoffee.Persistence.Contexts;

namespace ECoffee.Persistence.Repositories.Products
{
    public class ProductCommandRepository : CommandRepository<Product>, IProductCommandRepository
    {
        public ProductCommandRepository(ECoffeeDbContext context) : base(context){}
    }
}
