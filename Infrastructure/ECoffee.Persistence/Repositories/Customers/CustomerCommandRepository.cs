using ECoffee.Application.Repositories.Categories;
using ECoffee.Application.Repositories.Customers;
using ECoffee.Domain.Entities;
using ECoffee.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECoffee.Persistence.Repositories.Customers
{
    public class CustomerCommandRepository : CommandRepository<Customer>, ICustomerCommandRepository
    {
        public CustomerCommandRepository(ECoffeeDbContext context) : base(context)
        {
        }
    }
}
