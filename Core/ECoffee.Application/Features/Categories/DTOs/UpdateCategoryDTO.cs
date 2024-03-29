﻿using ECoffee.Application.Abstractions.DTO;

namespace ECoffee.Application.Features.Categories.DTOs
{
    public class UpdateCategoryDTO : IDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
