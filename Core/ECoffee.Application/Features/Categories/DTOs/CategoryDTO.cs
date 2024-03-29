﻿using ECoffee.Application.Abstractions.DTO;

namespace ECoffee.Application.Features.Categories.DTOs
{
    public class CategoryDTO : IDTO
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
