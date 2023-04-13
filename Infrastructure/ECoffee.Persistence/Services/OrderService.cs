using ECoffee.Application.Abstractions.Repositories.Orders;
using ECoffee.Application.Abstractions.Services;
using ECoffee.Application.Features.Customers.DTOs;
using ECoffee.Application.Features.Orders;
using ECoffee.Application.Features.Orders.DTOs;
using ECoffee.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECoffee.Persistence.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderCommandRepository _orderCommandRepository;
        private readonly IOrderQueryRepository _orderQueryRepository;
        private readonly ICustomerService _customerService;
        private readonly IProductService _productService;

        public OrderService(IOrderQueryRepository queryRepository, IOrderCommandRepository commandRepository, ICustomerService customerService, IProductService productService)
        {
            _orderQueryRepository = queryRepository;
            _orderCommandRepository = commandRepository;
            _customerService = customerService;
            _productService = productService;
        }

        public async Task<OrderDTO> AddAsync(AddOrderDTO addOrderDTO)
        {
            Order order = await _orderCommandRepository.AddAsync(OrderConverter.AddOrderDTOToOrder(addOrderDTO));
            order.Customer = CustomerConverter.GetByIdCustomerDTOToCustomer(await _customerService.GetByIdAsync(addOrderDTO.CustomerId));
            order.Products = await _productService.GetAllProductsByIds(addOrderDTO.ProductId);
            await _orderCommandRepository.SaveAsync();
            return OrderConverter.OrderToOrderDTO(order);
        }

        public async Task<OrderDTO> DeleteAsync(int id)
        {
            Order order = await _orderCommandRepository.RemoveAsync(id);
            await _orderCommandRepository.SaveAsync();
            return OrderConverter.OrderToOrderDTO(order);
        }

        public async Task<(List<GetAllOrdersDTO>, int totalCount)> GetAllAsync(int page, int size)
            => (OrderConverter.OrderListToGetAllOrderDTO(await _orderQueryRepository.GetAll().Where(c => c.IsActive == true).Include(c => c.Products).Skip(page * size).Take(size).ToListAsync()), await _orderQueryRepository.GetAll().CountAsync());

        public async Task<GetByIdOrderDTO> GetByIdAsync(int id)
            => OrderConverter.OrderToGetByIdOrderDTO(await _orderQueryRepository.Table.Include(o => o.Products).Include(c => c.Customer).FirstOrDefaultAsync(o => o.Id == id));

        public async Task<OrderDTO> UpdateAsync(UpdateOrderDTO updateOrderDTO)
        {
            Order order = OrderConverter.UpdateOrderDTOToOrder(updateOrderDTO);
            order.Customer = CustomerConverter.GetByIdCustomerDTOToCustomer(await _customerService.GetByIdAsync((await _orderQueryRepository.GetByIdAsync(updateOrderDTO.Id)).CustomerId));
            order.Products = await _productService.GetAllProductsByIds(updateOrderDTO.ProductId);
            await _orderCommandRepository.SaveAsync();
            return OrderConverter.OrderToOrderDTO(order);
        }
    }
}
