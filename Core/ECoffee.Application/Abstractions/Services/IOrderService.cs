using ECoffee.Application.Features.Customers.DTOs;
using ECoffee.Application.Features.Orders.DTOs;
using ECoffee.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECoffee.Application.Abstractions.Services
{
    public interface IOrderService
    {
        Task<List<GetAllOrdersDTO>> GetAllAsync();
        Task<GetByIdOrderDTO> GetByIdAsync(int id);
        Task<OrderDTO> AddAsync(AddOrderDTO addOrderDTO);
        Task<OrderDTO> UpdateAsync(UpdateOrderDTO updateOrderDTO);
        Task<OrderDTO> DeleteAsync(int id);
    }
}
