using ECoffee.Application.Features.Products.Commands.Add;
using ECoffee.Application.Features.Products.Commands.Delete;
using ECoffee.Application.Features.Products.Commands.Update;
using ECoffee.Application.Features.Products.DTOs;
using ECoffee.Application.Features.Products.Queries.GetAll;
using ECoffee.Application.Features.Products.Queries.GetById;
using ECoffee.Application.Utilities.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECoffee.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProductCommandRequest addProductCommandRequest)
        {
            IDataResult<ProductDTO> response = await _mediator.Send(addProductCommandRequest);
            return Ok(response);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute]DeleteProductCommandRequest deleteProductCommandRequest)
        {
            IDataResult<ProductDTO> response = await _mediator.Send(deleteProductCommandRequest);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody]UpdateProductCommandRequest updateProductCommandRequest)
        {
            IDataResult<ProductDTO> response = await _mediator.Send(updateProductCommandRequest);
            return Ok(response);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProductQueryRequest getByIdProductQueryRequest)
        {
            IDataResult<GetByIdProductDTO> response = await _mediator.Send(getByIdProductQueryRequest);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllProductQueryRequest getAllProductQueryRequest)
        {
            IDataResult<GetAllProductQueryResponse> response = await _mediator.Send(getAllProductQueryRequest);
            return Ok(response);
        }
    }
}