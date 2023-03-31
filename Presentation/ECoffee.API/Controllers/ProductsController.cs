using ECoffee.Application.Features.Categories.DTOs;
using ECoffee.Application.Features.Products.DTOs;
using ECoffee.Application.Services;
using ECoffee.Persistence.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECoffee.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProductDTO addProductDTO)
        { 
            return Ok(await _productService.AddAsync(addProductDTO));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _productService.DeleteAsync(id));
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductDTO updateProductDTO)
        {
            return Ok(await _productService.UpdateAsync(updateProductDTO));
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _productService.GetByIdAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productService.GetAllAsync());
        }
    }
}
