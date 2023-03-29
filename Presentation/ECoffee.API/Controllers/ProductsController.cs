using ECoffee.Application.Features.Products.DTOs;
using ECoffee.Application.Services;
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
            ProductDTO productDTO = await _productService.AddAsync(addProductDTO);
            return Ok(productDTO);
        }
    }
}
