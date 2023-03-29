using ECoffee.Application.Features.Customers.DTOs;
using ECoffee.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECoffee.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CustomersController: ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost] 
        public async Task<IActionResult> Add(AddCustomerDTO addCustomerDTO)
        {
            return Ok(await _customerService.AddAsync(addCustomerDTO));
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateCustomerDTO updateCustomerDTO)
        {
            return Ok(await _customerService.UpdateAsync(updateCustomerDTO));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _customerService.DeleteAsync(id));
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _customerService.GetByIdAsync(id));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _customerService.GetAllAsync());
        }
    }
}
