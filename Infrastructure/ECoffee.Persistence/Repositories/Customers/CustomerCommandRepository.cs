using ECoffee.Application.Abstractions.Repositories.Customers;
using ECoffee.Domain.Entities;
using ECoffee.Persistence.Contexts;

namespace ECoffee.Persistence.Repositories.Customers
{
    public class CustomerCommandRepository : CommandRepository<Customer>, ICustomerCommandRepository
    {
        public CustomerCommandRepository(ECoffeeDbContext context) : base(context)
        {
        }
    }
}
