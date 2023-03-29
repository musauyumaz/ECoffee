using ECoffee.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECoffee.Application.Repositories.Customers
{
    public interface ICustomerCommandRepository : ICommandRepository<Customer>
    {
    }
}
