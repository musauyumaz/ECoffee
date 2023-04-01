using ECoffee.Application.Features.Categories.Commands.Add;
using ECoffee.Application.Features.Categories.Commands.Delete;
using ECoffee.Application.Features.Categories.Commands.Update;
using ECoffee.Application.Features.Categories.DTOs;
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
            IDataResult<CategoryDTO> categoryDTO = await _mediator.Send(addCategoryCommandRequest);
            return Ok(categoryDTO);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryCommandRequest updateCategoryCommandRequest)
        {
            IDataResult<CategoryDTO> categoryDTO = await _mediator.Send(updateCategoryCommandRequest);
            return Ok(categoryDTO);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteCategoryCommandRequest deleteCategoryCommandRequest)
        {
            IDataResult<CategoryDTO> categoryDTO = await _mediator.Send(deleteCategoryCommandRequest);
            return Ok(categoryDTO);
        }
        //[HttpGet]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    return Ok(await _categoryService.GetByIdAsync(id));
        //}

        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    return Ok(await _categoryService.GetAllAsync());
        //}
    }
}
