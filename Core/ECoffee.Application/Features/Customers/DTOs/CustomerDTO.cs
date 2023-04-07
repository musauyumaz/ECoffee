﻿using ECoffee.Application.Abstractions.DTO;

namespace ECoffee.Application.Features.Customers.DTOs
{
    public class CustomerDTO:IDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        //todo IsActive i de çagırabiliriz //Serkan
    }
}