using ECoffee.Application.Abstractions.Repositories.Customers;
using ECoffee.Application.Abstractions.Services;
using ECoffee.Application.Features.Customers.DTOs;
using ECoffee.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECoffee.Persistence.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerCommandRepository _customerCommandRepository;
        private readonly ICustomerQueryRepository _customerQueryRepository;

        public CustomerService(ICustomerCommandRepository customerCommandRepository, ICustomerQueryRepository customerQueryRepository)
        {
            _customerCommandRepository = customerCommandRepository;
            _customerQueryRepository = customerQueryRepository;
        }

        public async Task<CustomerDTO> AddAsync(AddCustomerDTO addCustomerDTO)
        {
            Customer customer = await _customerCommandRepository.AddAsync(CustomerConverter.AddCustomerDTOToCustomer(addCustomerDTO));
            await _customerCommandRepository.SaveAsync();
            return CustomerConverter.CustomerToCustomerDTO(customer);
        }

        public async Task<CustomerDTO> DeleteAsync(int id)
        {
            Customer customer = await _customerCommandRepository.RemoveAsync(id);
            await _customerCommandRepository.SaveAsync();
            return CustomerConverter.CustomerToCustomerDTO(customer);
        }

        public async Task<(List<GetAllCustomersDTO> customers, int totalCount)> GetAllAsync(int page, int size)
            => (CustomerConverter.CustomerListToGetAllCustomersDTO(await _customerQueryRepository.GetAll().Skip(size * page).Take(size).ToListAsync()), await _customerQueryRepository.GetAll().CountAsync());
        public async Task<GetByIdCustomerDTO> GetByIdAsync(int id)
        => CustomerConverter.CustomerToGetByIdCustomerDTO(await _customerQueryRepository.GetByIdAsync(id));

        public async Task<CustomerDTO> UpdateAsync(UpdateCustomerDTO updateCustomerDTO)
        {
            Customer customer = await _customerQueryRepository.GetByIdAsync(updateCustomerDTO.Id);
            //Customer updatedCustomer = CustomerConverter.UpdateCustomerDTOToCustomer(updateCustomerDTO, customer);
            customer.Name = updateCustomerDTO.Name;
            customer.Surname = updateCustomerDTO.Surname;
            customer.Email = updateCustomerDTO.Surname;
            customer.IsActive = updateCustomerDTO.IsActive;
            _customerCommandRepository.Update(customer);
            await _customerCommandRepository.SaveAsync();
            return CustomerConverter.CustomerToCustomerDTO(customer);
        }
    }
}
//Fluent Validation