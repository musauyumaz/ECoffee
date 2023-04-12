using ECoffee.Application.Features.Customers.DTOs;
using ECoffee.Application.Utilities.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECoffee.Application.Features.Customers.Queries.GetById
{
    public class GetByIdCustomerQueryRequest:IRequest<IDataResult<GetByIdCustomerDTO>>
    {
        public int Id { get; set; }
    }

}
