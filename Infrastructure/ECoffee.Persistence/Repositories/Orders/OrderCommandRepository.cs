using ECoffee.Application.Abstractions.Repositories.Orders;
using ECoffee.Domain.Entities;
using ECoffee.Persistence.Contexts;

namespace ECoffee.Persistence.Repositories.Orders
{
    public class OrderCommandRepository : CommandRepository<Order>, IOrderCommandRepository
    {
        public OrderCommandRepository(ECoffeeDbContext context) : base(context)
        {
        }
    }
}
