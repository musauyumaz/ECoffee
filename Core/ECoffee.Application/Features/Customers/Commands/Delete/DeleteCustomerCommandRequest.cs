using ECoffee.Application.Features.Customers.DTOs;
using ECoffee.Application.Features.Products.DTOs;
using ECoffee.Application.Utilities.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECoffee.Application.Features.Customers.Commands.Delete
{
    public class DeleteCustomerCommandRequest:IRequest<IDataResult<CustomerDTO>>
    {
        public string Id { get; set; }

    }
}
