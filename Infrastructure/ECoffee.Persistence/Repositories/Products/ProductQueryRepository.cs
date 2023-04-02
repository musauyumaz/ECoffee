using ECoffee.Application.Abstractions.Repositories.Products;
using ECoffee.Domain.Entities;
using ECoffee.Persistence.Contexts;

namespace ECoffee.Persistence.Repositories.Products
{
    public class ProductQueryRepository : QueryRepository<Product>, IProductQueryRepository
    {
        public ProductQueryRepository(ECoffeeDbContext context) : base(context) { }
    }
}
