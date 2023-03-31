using ECoffee.Application.Features.Categories.DTOs;
using ECoffee.Application.Features.Orders.DTOs;
using ECoffee.Application.Services;
using ECoffee.Persistence.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECoffee.API.Controllers
{
    [Route("api/[controller][action]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddOrderDTO addOrderDTO)
        {
            return Ok(await _orderService.AddAsync(addOrderDTO));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _orderService.GetAllAsync());
        }
    }
}
