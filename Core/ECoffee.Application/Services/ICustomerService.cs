using ECoffee.Application.Features.Customers.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECoffee.Application.Services
{
    public interface ICustomerService
    {
        Task<List<GetAllCustomersDTO>> GetAllAsync();
        Task<GetByIdCustomerDTO> GetByIdAsync(int id);
        Task<CustomerDTO> AddAsync(AddCustomerDTO addCustomerDTO);
        Task<CustomerDTO> UpdateAsync(UpdateCustomerDTO updateCustomerDTO);
        Task<CustomerDTO> DeleteAsync(int id);
    }
}
