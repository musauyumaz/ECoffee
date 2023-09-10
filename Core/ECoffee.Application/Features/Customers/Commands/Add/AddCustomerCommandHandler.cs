using ECoffee.Application.Abstractions.Services;
using ECoffee.Application.Features.Customers.DTOs;
using ECoffee.Application.Utilities.Results;
using MediatR;

namespace ECoffee.Application.Features.Customers.Commands.Add
{
    public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommandRequest, IDataResult<CustomerDTO>>
    {
        private ICustomerService _customerService;
        private IMailService _mailService;

        public AddCustomerCommandHandler(ICustomerService customerService, IMailService mailService)
        {
            _customerService = customerService;
            _mailService = mailService;
        }

        public async Task<IDataResult<CustomerDTO>> Handle(AddCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            CustomerDTO customerDTO = await _customerService.AddAsync(new() { Name = request.Name, Surname = request.Surname, Email = request.Email, Password = request.Password });
            await _mailService.WelcomeUserMailAsync(customerDTO.Email, customerDTO.FullName);
            return new SuccessDataResult<CustomerDTO>("Müşteri Eklendi", customerDTO);
        }

    }
}
