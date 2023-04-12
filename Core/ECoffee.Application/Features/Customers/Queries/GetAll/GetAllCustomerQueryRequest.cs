using ECoffee.Application.Utilities.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECoffee.Application.Features.Customers.Queries.GetAll
{
    public class GetAllCustomerQueryRequest:IRequest<IDataResult<GetAllCustomerQueryResponse>>
    {
        public int Page { get; set; }
        public int Size { get; set; }

    }
}
