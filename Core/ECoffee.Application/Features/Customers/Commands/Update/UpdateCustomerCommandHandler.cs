using ECoffee.Application.Abstractions.Services;
using ECoffee.Application.Features.Customers.DTOs;
using ECoffee.Application.Utilities.Results;
using MediatR;

namespace ECoffee.Application.Features.Customers.Commands.Update
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommandRequest, IDataResult<CustomerDTO>>
    {
        private ICustomerService _customerService;

        public UpdateCustomerCommandHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<IDataResult<CustomerDTO>> Handle(UpdateCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            CustomerDTO customerDTO = await _customerService.UpdateAsync(new() { Id = request.Id.ToString(), Name = request.Name, Surname = request.Surname, Email = request.Email });
            return new SuccessDataResult<CustomerDTO>("Kullanici Güncellendi", customerDTO);
        }
    }
}
