using ECoffee.Application.Repositories.Orders;
using ECoffee.Domain.Entities;
using ECoffee.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECoffee.Persistence.Repositories.Orders
{
    public class OrderQueryRepository : QueryRepository<Order>, IOrderQueryRepository
    {
        public OrderQueryRepository(ECoffeeDbContext eCoffeeDbContext) : base(eCoffeeDbContext)
        {
        }
    }
}
