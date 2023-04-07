using ECoffee.Application.Abstractions.Services;
using ECoffee.Application.Features.Customers.DTOs;
using ECoffee.Application.Utilities.Results;
using MediatR;

namespace ECoffee.Application.Features.Customers.Commands.Add
{
    public class AddCustomerCommandHandler:IRequestHandler<AddCustomerCommandRequest,IDataResult<CustomerDTO>>
    {
        private ICustomerService _customerService;

        public AddCustomerCommandHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<IDataResult<CustomerDTO>> Handle(AddCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            CustomerDTO customerDTO = await _customerService.AddAsync(CustomerConverter.AddCustomerCommandRequestToAddCustomerDTO(request));
            return new SuccessDataResult<CustomerDTO>("Müşteri Eklendi",customerDTO);
        }

    }
}
