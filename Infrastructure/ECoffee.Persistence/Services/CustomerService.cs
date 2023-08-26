using ECoffee.Application.Abstractions.Repositories.Customers;
using ECoffee.Application.Abstractions.Services;
using ECoffee.Application.Features.Categories.DTOs;
using ECoffee.Application.Features.Customers.DTOs;
using ECoffee.Domain.Entities;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;

namespace ECoffee.Persistence.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerCommandRepository _customerCommandRepository;
        private readonly ICustomerQueryRepository _customerQueryRepository;
        private readonly IDataProtector _dataProtector;

        public CustomerService(ICustomerCommandRepository customerCommandRepository, ICustomerQueryRepository customerQueryRepository, IDataProtectionProvider dataProtectionProvider)
        {
            _customerCommandRepository = customerCommandRepository;
            _customerQueryRepository = customerQueryRepository;
            _dataProtector = dataProtectionProvider.CreateProtector("customers");
        }

        public async Task<CustomerDTO> AddAsync(AddCustomerDTO addCustomerDTO)
        {
            Customer customer = await _customerCommandRepository.AddAsync(new() { Name = addCustomerDTO.Name, Surname = addCustomerDTO.Surname, Email = addCustomerDTO.Email, Password = addCustomerDTO.Password });
            await _customerCommandRepository.SaveAsync();
            return new() { Id = _dataProtector.Protect(customer.Id.ToString()), Name = customer.Name, Surname = customer.Surname, Email = customer.Email };
        }

        public async Task<CustomerDTO> DeleteAsync(string id)
        {
            Customer customer = await _customerCommandRepository.RemoveAsync(int.Parse(_dataProtector.Unprotect(id)));
            await _customerCommandRepository.SaveAsync();
            return new() { Id = _dataProtector.Protect(customer.Id.ToString()), Name = customer.Name, Surname = customer.Surname, Email = customer.Email };
        }

        public async Task<(List<GetAllCustomersDTO> customers, int totalCount)> GetAllAsync(int page, int size)
            => (await _customerQueryRepository.GetAll().Where(c => c.IsActive == true).Skip(page * size).Take(size).Select(c => new GetAllCustomersDTO
               {
                   Id = _dataProtector.Protect(c.Id.ToString()),
                   Name = c.Name,
                   Surname = c.Surname,
                   Email = c.Email
               }).ToListAsync(), await _customerQueryRepository.GetAll().CountAsync());
        
        public async Task<GetByIdCustomerDTO> GetByIdAsync(string id)
        {
            Customer customer = await _customerCommandRepository.RemoveAsync(int.Parse(_dataProtector.Unprotect(id)));
            return new() { Id = _dataProtector.Unprotect(customer.Id.ToString()), Name = customer.Name, Surname = customer.Surname, Email = customer.Email };
        }

        public async Task<CustomerDTO> UpdateAsync(UpdateCustomerDTO updateCustomerDTO)
        {
            Customer customer = await _customerQueryRepository.GetByIdAsync(int.Parse(_dataProtector.Unprotect(updateCustomerDTO.Id)));
            //Customer updatedCustomer = CustomerConverter.UpdateCustomerDTOToCustomer(updateCustomerDTO, customer);
            customer.Name = updateCustomerDTO.Name;
            customer.Surname = updateCustomerDTO.Surname;
            customer.Email = updateCustomerDTO.Surname;
            customer.IsActive = updateCustomerDTO.IsActive;
            _customerCommandRepository.Update(customer);
            await _customerCommandRepository.SaveAsync();
            return new() { Id = _dataProtector.Unprotect(customer.Id.ToString()), Name = customer.Name, Surname = customer.Surname, Email = customer.Email };
        }
    }
}
//Fluent Validation
//ToDo customer.Email 45. satır