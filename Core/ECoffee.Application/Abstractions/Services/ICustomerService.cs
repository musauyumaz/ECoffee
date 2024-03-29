﻿using ECoffee.Application.Features.Customers.DTOs;
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
        Task<(List<GetAllCustomersDTO> customers,int totalCount)> GetAllAsync(int page,int size);
        Task<GetByIdCustomerDTO> GetByIdAsync(string id);
        Task<CustomerDTO> AddAsync(AddCustomerDTO addCustomerDTO);
        Task<CustomerDTO> UpdateAsync(UpdateCustomerDTO updateCustomerDTO);
        Task<CustomerDTO> DeleteAsync(string id);
    }
}
