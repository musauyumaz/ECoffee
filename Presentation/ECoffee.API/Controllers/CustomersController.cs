using ECoffee.Application.Features.Customers.Commands.Add;
using ECoffee.Application.Features.Customers.Commands.Delete;
using ECoffee.Application.Features.Customers.Commands.Update;
using ECoffee.Application.Features.Customers.DTOs;
using ECoffee.Application.Features.Customers.Queries.GetAll;
using ECoffee.Application.Features.Customers.Queries.GetById;
using ECoffee.Application.Utilities.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECoffee.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCustomerCommandRequest addCustomerCommandRequest)
        {
            IDataResult<CustomerDTO> response = await _mediator.Send(addCustomerCommandRequest);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerCommandRequest updateCustomerCommandRequest)
        {
            IDataResult<CustomerDTO> response = await _mediator.Send(updateCustomerCommandRequest);
            return Ok(response);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteCustomerCommandRequest deleteCustomerCommandRequest)
        {
            IDataResult<CustomerDTO> response = await _mediator.Send(deleteCustomerCommandRequest);
            return Ok(response);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdCustomerQueryRequest getByIdCustomerQueryRequest)
        {
            IDataResult<GetByIdCustomerDTO> response = await _mediator.Send(getByIdCustomerQueryRequest);
            return Ok(response);

        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCustomerQueryRequest getAllCustomerQueryRequest)
        {
            IDataResult<GetAllCustomerQueryResponse> result = await _mediator.Send(getAllCustomerQueryRequest);
            return Ok(result);
        }
    }
}
