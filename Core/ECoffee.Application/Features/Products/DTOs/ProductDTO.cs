﻿using ECoffee.Application.Abstractions.DTO;

namespace ECoffee.Application.Features.Products.DTOs
{
    public class ProductDTO : IDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UnitsInStock { get; set; }
        public float Price { get; set; }
    }
}
