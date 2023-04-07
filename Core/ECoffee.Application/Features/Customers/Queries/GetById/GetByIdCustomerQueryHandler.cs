using ECoffee.Application.Abstractions.Services;
using ECoffee.Application.Features.Customers.DTOs;
using ECoffee.Application.Utilities.Results;
using MediatR;

namespace ECoffee.Application.Features.Customers.Queries.GetById
{
    public class GetByIdCustomerQueryHandler : IRequestHandler<GetByIdCustomerQueryRequest, IDataResult<GetByIdCustomerDTO>>
    {
        private ICustomerService _customerService;

        public GetByIdCustomerQueryHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<IDataResult<GetByIdCustomerDTO>> Handle(GetByIdCustomerQueryRequest request, CancellationToken cancellationToken)
        {
            GetByIdCustomerDTO getByIdCustomerDTO = await _customerService.GetByIdAsync(request.Id);
            return new SuccessDataResult<GetByIdCustomerDTO>("Müşteri Getirildi", getByIdCustomerDTO);
        }
    }

}
