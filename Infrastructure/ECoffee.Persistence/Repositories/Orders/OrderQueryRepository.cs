using ECoffee.Application.Abstractions.Repositories.Orders;
using ECoffee.Domain.Entities;
using ECoffee.Persistence.Contexts;

namespace ECoffee.Persistence.Repositories.Orders
{
    public class OrderQueryRepository : QueryRepository<Order>, IOrderQueryRepository
    {
        public OrderQueryRepository(ECoffeeDbContext eCoffeeDbContext) : base(eCoffeeDbContext)
        {
        }
    }
}
