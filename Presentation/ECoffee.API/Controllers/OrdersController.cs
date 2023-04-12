using ECoffee.Application.Features.Customers.Commands.Delete;
using ECoffee.Application.Features.Customers.DTOs;
using ECoffee.Application.Features.Customers.Queries.GetAll;
using ECoffee.Application.Features.Customers.Queries.GetById;
using ECoffee.Application.Features.Orders.Commands.Add;
using ECoffee.Application.Features.Orders.Commands.Delete;
using ECoffee.Application.Features.Orders.Commands.Update;
using ECoffee.Application.Features.Orders.DTOs;
using ECoffee.Application.Features.Orders.Queries.GetAll;
using ECoffee.Application.Features.Orders.Queries.GetById;
using ECoffee.Application.Utilities.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECoffee.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddOrderCommandRequest addOrderCommandRequest)
        {
            IDataResult<OrderDTO> response = await _mediator.Send(addOrderCommandRequest);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateOrderCommandRequest updateOrderCommandRequest)
        {
            IDataResult<OrderDTO> response = await _mediator.Send(updateOrderCommandRequest);
            return Ok(response);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteOrderCommandRequest deleteOrderCommandRequest)
        {
            IDataResult<OrderDTO> response = await _mediator.Send(deleteOrderCommandRequest);
            return Ok(response);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdOrderQueryRequest getByIdOrderQueryRequest)
        {
            IDataResult<GetByIdOrderDTO> response = await _mediator.Send(getByIdOrderQueryRequest);
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllOrderQueryRequest getAllOrderQueryRequest)
        {
            IDataResult<GetAllOrderQueryResponse> result = await _mediator.Send(getAllOrderQueryRequest);
            return Ok(result);
        }
    }
}
