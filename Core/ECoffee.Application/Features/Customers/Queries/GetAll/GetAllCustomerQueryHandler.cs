using ECoffee.Application.Abstractions.Services;
using ECoffee.Application.Features.Customers.DTOs;
using ECoffee.Application.Utilities.Results;
using MediatR;

namespace ECoffee.Application.Features.Customers.Queries.GetAll
{
    public class GetAllCustomerQueryHandler : IRequestHandler<GetAllCustomerQueryRequest, IDataResult<GetAllCustomerQueryResponse>>
    {
        private ICustomerService _customerService;

        public GetAllCustomerQueryHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<IDataResult<GetAllCustomerQueryResponse>> Handle(GetAllCustomerQueryRequest request, CancellationToken cancellationToken)
        {
            (List<GetAllCustomersDTO> Customers, int TotalCount) data = await _customerService.GetAllAsync(request.Page, request.Size);
            return new SuccessDataResult<GetAllCustomerQueryResponse>("Müşteriler Listelendi", new(){ GetAllCustomersDTOs = data.Customers, TotalCount = data.TotalCount });
        }
    }
}
