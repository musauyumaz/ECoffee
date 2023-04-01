using ECoffee.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECoffee.Application.Abstractions.Repositories.Customers
{
    public interface ICustomerCommandRepository : ICommandRepository<Customer>
    {
    }
}
