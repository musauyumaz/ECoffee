using ECoffee.Application.Repositories.Orders;
using ECoffee.Domain.Entities;
using ECoffee.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ECoffee.Persistence.Repositories.Orders
{
    public class OrderCommandRepository : CommandRepository<Order>, IOrderCommandRepository
    {
        public OrderCommandRepository(ECoffeeDbContext context) : base(context)
        {
        }
    }
}
