using ECoffee.Application.Features.Categories.DTOs;
using ECoffee.Application.Features.Orders.DTOs;
using ECoffee.Application.Repositories.Orders;
using ECoffee.Application.Services;
using ECoffee.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECoffee.Persistence.Services
{
    public class OrderService:IOrderService
    {
        private readonly IOrderCommandRepository _commandRepository;
        private readonly IOrderQueryRepository _orderQueryRepository;

        public OrderService(IOrderQueryRepository orderQueryRepository, IOrderCommandRepository commandRepository)
        {
            _orderQueryRepository = orderQueryRepository;
            _commandRepository = commandRepository;
        }

        public async Task<OrderDTO> AddAsync(AddOrderDTO addOrderDTO)
        {
            Order order = await _commandRepository.AddAsync(OrderConverter.AddOrderDTOToOrder(addOrderDTO));
            await _commandRepository.SaveAsync();
            return OrderConverter.OrderToOrderDTO(order);
        }

        public async Task<OrderDTO> DeleteAsync(int id)
        {
            Order order = await _commandRepository.RemoveAsync(id);
            await _commandRepository.SaveAsync();
            return OrderConverter.OrderToOrderDTO(order);
        }

        public async Task<List<GetAllOrdersDTO>> GetAllAsync()
        => OrderConverter.OrderListToGetAllOrdersDTO(await _orderQueryRepository.GetAll().Include(p => p.Products).Include(c=>c.Customer).ToListAsync());
        

        public async Task<GetByIdOrderDTO> GetByIdAsync(int id)
         => OrderConverter.OrderToGetByIdOrderDTO(await _orderQueryRepository.Table.Include(p => p.Products).Include(c=>c.Customer).FirstOrDefaultAsync(o => o.Id == id));

        public async Task<OrderDTO> UpdateAsync(UpdateOrderDTO updateOrderDTO)
        {
            Order order = OrderConverter.UpdateOrderDTOToOrder(updateOrderDTO);
            _commandRepository.Update(order);
            await _commandRepository.SaveAsync();
            return OrderConverter.OrderToOrderDTO(order);
        }
    }
}
