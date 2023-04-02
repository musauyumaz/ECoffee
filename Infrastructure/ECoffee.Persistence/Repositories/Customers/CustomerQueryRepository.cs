using ECoffee.Application.Abstractions.Repositories.Customers;
using ECoffee.Domain.Entities;
using ECoffee.Persistence.Contexts;

namespace ECoffee.Persistence.Repositories.Customers
{
    public class CustomerQueryRepository : QueryRepository<Customer>, ICustomerQueryRepository
    {
        public CustomerQueryRepository(ECoffeeDbContext eCoffeeDbContext) : base(eCoffeeDbContext)
        {
        }
    }
}
