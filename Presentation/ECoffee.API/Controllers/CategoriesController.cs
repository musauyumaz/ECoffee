using ECoffee.Application.Features.Categories.Commands.Add;
using ECoffee.Application.Features.Categories.Commands.Delete;
using ECoffee.Application.Features.Categories.Commands.Update;
using ECoffee.Application.Features.Categories.DTOs;
using ECoffee.Application.Features.Categories.Queries.GetAll;
using ECoffee.Application.Features.Categories.Queries.GetById;
using ECoffee.Application.Utilities.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECoffee.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCategoryCommandRequest addCategoryCommandRequest)
        {
            IDataResult<CategoryDTO> response = await _mediator.Send(addCategoryCommandRequest);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryCommandRequest updateCategoryCommandRequest)
        {
            IDataResult<CategoryDTO> response = await _mediator.Send(updateCategoryCommandRequest);
            return Ok(response);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute]DeleteCategoryCommandRequest deleteCategoryCommandRequest)
        {
            IDataResult<CategoryDTO> response = await _mediator.Send(deleteCategoryCommandRequest);
            return Ok(response);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute]GetByIdCategoryQueryRequest getByIdCategoryRequest)
        {
            IDataResult<GetByIdCategoryDTO> response = await _mediator.Send(getByIdCategoryRequest);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCategoryQueryRequest getAllCategoryQueryRequest)
        {
            IDataResult<GetAllCategoryQueryResponse> response = await _mediator.Send(getAllCategoryQueryRequest);
            return Ok(response);
        }
    }
}
