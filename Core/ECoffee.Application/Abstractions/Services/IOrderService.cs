using ECoffee.Application.Features.Categories.DTOs;
using ECoffee.Application.Features.Orders.DTOs;

namespace ECoffee.Application.Abstractions.Services
{
    public interface IOrderService
    {
        Task<(List<GetAllOrdersDTO>, int totalCount)> GetAllAsync(int page, int size);
        Task<GetByIdOrderDTO> GetByIdAsync(string id);
        Task<OrderDTO> AddAsync(AddOrderDTO addOrderDTO);
        Task<OrderDTO> UpdateAsync(UpdateOrderDTO updateOrderDTO);
        Task<OrderDTO> DeleteAsync(string id);
    }
}
