using ECoffee.Application.Features.Customers.DTOs;
using ECoffee.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECoffee.Application.Abstractions.Services
{
    public interface ICustomerService
    {
        Task<(List<GetAllCustomersDTO>,int TotalCount)> GetAllAsync(int page,int size);
        Task<GetByIdCustomerDTO> GetByIdAsync(int id);
        Task<CustomerDTO> AddAsync(AddCustomerDTO addCustomerDTO);
        Task<CustomerDTO> UpdateAsync(UpdateCustomerDTO updateCustomerDTO);
        Task<CustomerDTO> DeleteAsync(int id);
    }
}
