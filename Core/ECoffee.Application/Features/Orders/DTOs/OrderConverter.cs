using ECoffee.Application.Features.Products.DTOs;
using ECoffee.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECoffee.Application.Features.Orders.DTOs
{
    public class OrderConverter
    {
        public static Order AddOrderDTOToOrder(AddOrderDTO addOrderDTO)
         => new()
         {
             Customer = new() { Email = addOrderDTO.Customer.Email, Name = addOrderDTO.Customer.Name, Surname = addOrderDTO.Customer.Surname },
             Products = addOrderDTO.Products.Select(p => new Product()
             {
                 Name = p.Name,
                 Price = p.Price,
                 Description = p.Description,
                 UnitsInStock = p.UnitsInStock,
                 Id = p.Id
             }).ToList()
         };

        public static Order UpdateOrderDTOToOrder(UpdateOrderDTO updateOrderDTO)
            => new() { Id = updateOrderDTO.Id, Customer = updateOrderDTO.Customer, Products = updateOrderDTO.Products, TotalPrice = updateOrderDTO.TotalPrice, IsActive = updateOrderDTO.IsActive };
        public static OrderDTO OrderToOrderDTO(Order order)
            => new() { Id = order.Id, Customer = order.Customer, Products = order.Products, TotalPrice = order.TotalPrice };
        public static GetByIdOrderDTO OrderToGetByIdOrderDTO(Order order)
            => new() { Id = order.Id, Customer = order.Customer, Products = order.Products, TotalPrice = order.TotalPrice };

        public static List<GetAllOrdersDTO> OrderListToGetAllOrdersDTO(List<Order> orders)
        => orders.Select(o => new GetAllOrdersDTO()
        {
            Id = o.Id,
            Customer = new() { Name = o.Customer.Name, Email = o.Customer.Email, Surname = o.Customer.Surname },
            Products = o.Products.Select(p => new ProductDTO() { Id = p.Id, Name = p.Name, Description = p.Description, Price = p.Price, UnitsInStock = p.UnitsInStock }).ToList(),
            TotalPrice = o.Products.Sum(p => p.Price)
        }).ToList();

    }
}
