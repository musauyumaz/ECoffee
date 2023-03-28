using ECoffee.Application.Features.Categories.DTOs;
using ECoffee.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECoffee.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCategoryDTO addCategoryDTO)
        {
            return Ok(await _categoryService.AddAsync(addCategoryDTO));
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryDTO updateCategoryDTO)
        {
            return Ok(await _categoryService.UpdateAsync(updateCategoryDTO));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _categoryService.DeleteAsync(id));
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _categoryService.GetByIdAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _categoryService.GetAllAsync());
        }
    }
}
