using ECoffee.Application.Features.Customers.DTOs;
using ECoffee.Application.Features.Products.DTOs;
using ECoffee.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECoffee.Application.Features.Orders.DTOs
{
    public class GetAllOrdersDTO
    {
        public int Id { get; set; }
        public CustomerDTO Customer { get; set; }
        public List<ProductDTO> Products { get; set; }
        public double TotalPrice { get; set; }
    }
}
