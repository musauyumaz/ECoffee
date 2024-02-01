using ECoffee.Application.Abstractions.Repositories.Orders;
using ECoffee.Application.Abstractions.Services;
using ECoffee.Application.Features.Customers.DTOs;
using ECoffee.Application.Features.Orders;
using ECoffee.Application.Features.Orders.DTOs;
using ECoffee.Domain.Entities;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ECoffee.Persistence.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderCommandRepository _orderCommandRepository;
        private readonly IOrderQueryRepository _orderQueryRepository;
        private readonly ICustomerService _customerService;
        private readonly IProductService _productService;
        private readonly IDataProtector _dataProtector;

        public OrderService(IOrderQueryRepository queryRepository, IOrderCommandRepository commandRepository, ICustomerService customerService, IProductService productService, IDataProtectionProvider dataProtectionProvider)
        {
            _orderQueryRepository = queryRepository;
            _orderCommandRepository = commandRepository;
            _customerService = customerService;
            _productService = productService;
            _dataProtector = dataProtectionProvider.CreateProtector("Order");
        }

        public async Task<OrderDTO> AddAsync(AddOrderDTO addOrderDTO)
        {
            Order order = await _orderCommandRepository.AddAsync(new() { CustomerId = addOrderDTO.CustomerId, Note = addOrderDTO.Note }); ;
            GetByIdCustomerDTO getByIdCustomerDTO = await _customerService.GetByIdAsync(_dataProtector.Unprotect(addOrderDTO.CustomerId.ToString()));
            order.Customer = new Customer() { Id = int.Parse(_dataProtector.Unprotect(getByIdCustomerDTO.Id)), Name = getByIdCustomerDTO.Name, Surname = getByIdCustomerDTO.Surname, Email = getByIdCustomerDTO.Email };

            order.Products = await _productService.GetAllProductsByIds(addOrderDTO.ProductId);
            await _orderCommandRepository.SaveAsync();
            return new OrderDTO() { Id = _dataProtector.Protect( order.Id.ToString()), CustomerName = $"{order.Customer.Name} {order.Customer.Surname}", ProductNames = order.Products.Select(p => p.Name).ToList() };
        }

        public async Task<OrderDTO> DeleteAsync(string id)
        {
            Order order = await _orderCommandRepository.RemoveAsync(int.Parse(_dataProtector.Unprotect(id)));
            await _orderCommandRepository.SaveAsync();
            return new OrderDTO() { Id = _dataProtector.Protect(order.Id.ToString()), CustomerName = $"{order.Customer.Name} {order.Customer.Surname}", ProductNames = order.Products.Select(p => p.Name).ToList() };

        }

        public async Task<(List<GetAllOrdersDTO>, int totalCount)> GetAllAsync(int page, int size)
        {
            var orders = await _orderQueryRepository.GetAll().Where(c => c.IsActive == true).Include(c => c.Products).Skip(page * size).Take(size).ToListAsync();
            List<GetAllOrdersDTO> result = orders.Select(o => new GetAllOrdersDTO()
            {
                Id = o.Id,
                CustomerName =o.Customer.Name,
                ProductNames=o.Products.Select(p => p.Name).ToList()
            }).ToList();
            return (result,await _orderQueryRepository.GetAll().CountAsync());
        }
        public async Task<GetByIdOrderDTO> GetByIdAsync(string id)
        {
            Order order = await _orderQueryRepository.Table.Include(o => o.Products).Include(c => c.Customer).FirstOrDefaultAsync(o => o.Id == int.Parse(_dataProtector.Unprotect(id)));
            return new GetByIdOrderDTO() { Id=_dataProtector.Protect(order.Id.ToString()), CustomerName=order.Customer.Name,ProductNames=order.Products.Select(p=>p.Name).ToList()};
        }
        public async Task<OrderDTO> UpdateAsync(UpdateOrderDTO updateOrderDTO)
        {
            Order order = await _orderQueryRepository.GetByIdAsync(updateOrderDTO.Id);
            //order.Products = await _productService.GetAllProductsByIds(updateOrderDTO.ProductId));
            order.IsActive = updateOrderDTO.IsActive;
            _orderCommandRepository.Update(order);
            await _orderCommandRepository.SaveAsync();
            return new OrderDTO() { Id = _dataProtector.Protect(order.Id.ToString()), CustomerName = order.Customer.Name, ProductNames = order.Products.Select(p => p.Name).ToList() };
        }
    }
}
