using ECoffee.Application.Features.Orders.DTOs;
using ECoffee.Domain.Entities;

namespace ECoffee.Application.Features.Orders
{
    public static class OrderConverter
    {
        public static OrderDTO OrderToCustomerDTO(Order order)
           => new() { Id = order.Id, CustomerName = $"{order.Customer.Name} {order.Customer.Surname}", ProductNames = order.Products.Select(p => p.Name).ToList() };

        public static Order AddOrderDTOToOrder(AddOrderDTO addOrderDTO)
            => new() { CustomerId = addOrderDTO.CustomerId, Note = addOrderDTO.Note };
        public static Order UpdateOrderDTOToOrder(UpdateOrderDTO updateOrderDTO)
            => new() { Id = updateOrderDTO.Id, IsActive = updateOrderDTO.IsActive };

        public static GetByIdOrderDTO OrderToGetByIdOrderDTO(Order order)
            => new() { CustomerName = $"{order.Customer.Name} {order.Customer.Surname}", ProductNames = order.Products.Select(p => p.Name).ToList() };

        public static List<GetAllOrdersDTO> OrderListToGetAllOrderDTO(List<Order> orders)
            => orders.Select(c => new GetAllOrdersDTO { Id = c.Id, CustomerName = $"{c.Customer.Name} {c.Customer.Surname}", ProductNames = c.Products.Select(p => p.Name).ToList() }).ToList();

    }
}
