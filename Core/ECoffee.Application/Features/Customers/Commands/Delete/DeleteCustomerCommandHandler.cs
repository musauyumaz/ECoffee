using ECoffee.Application.Abstractions.Services;
using ECoffee.Application.Features.Customers.DTOs;
using ECoffee.Application.Utilities.Results;
using MediatR;

namespace ECoffee.Application.Features.Customers.Commands.Delete
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommandRequest, IDataResult<CustomerDTO>>
    {
        private ICustomerService _customerService;

        public DeleteCustomerCommandHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<IDataResult<CustomerDTO>> Handle(DeleteCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            CustomerDTO customerDTO= await _customerService.DeleteAsync(request.Id);
            return new SuccessDataResult<CustomerDTO>("Müşteri Başarıyla Silindi",customerDTO);
        }
    }
}
