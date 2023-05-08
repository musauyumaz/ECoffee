using ECoffee.Application.Features.Categories.Commands.Add;
using ECoffee.Application.Features.Categories.Commands.Update;
using ECoffee.Application.Features.Categories.DTOs;
using ECoffee.Application.Features.Orders.Commands.Add;
using ECoffee.Application.Features.Orders.Commands.Update;
using ECoffee.Application.Features.Orders.DTOs;
using ECoffee.Domain.Entities;

namespace ECoffee.Application.Features.Orders
{
    public static class OrderConverter
    {
        public static OrderDTO OrderToOrderDTO(Order order)
           => new() { Id = order.Id, CustomerName = $"{order.Customer.Name} {order.Customer.Surname}", ProductNames = order.Products.Select(p => p.Name).ToList() };

        public static Order AddOrderDTOToOrder(AddOrderDTO addOrderDTO)
            => new() { CustomerId = addOrderDTO.CustomerId, Note = addOrderDTO.Note };
        public static Order UpdateOrderDTOToOrder(UpdateOrderDTO updateOrderDTO)
            => new() { Id = updateOrderDTO.Id, IsActive = updateOrderDTO.IsActive };

        public static GetByIdOrderDTO OrderToGetByIdOrderDTO(Order order)
        {
            GetByIdOrderDTO getByIdOrderDTO = new() { Id = order.Id, CustomerName = $"{order.Customer.Name} {order.Customer.Surname}", ProductNames = order.Products.Select(p => p.Name).ToList() };
            return getByIdOrderDTO;
        }

        public static List<GetAllOrdersDTO> OrderListToGetAllOrderDTO(List<Order> orders)
            => orders.Select(c => new GetAllOrdersDTO { Id = c.Id, CustomerName = $"{c.Customer.Name} {c.Customer.Surname}", ProductNames = c.Products.Select(p => p.Name).ToList() }).ToList();
        public static AddOrderDTO AddOrderCommandRequestToAddOrderDTO(AddOrderCommandRequest addOrderCommandRequest)
           => new() { CustomerId = addOrderCommandRequest.CustomerId, ProductId = addOrderCommandRequest.ProductIds, Note = addOrderCommandRequest.Note };

    }
}
