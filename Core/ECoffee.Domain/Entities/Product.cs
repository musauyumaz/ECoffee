﻿using ECoffee.Domain.Entities.Common;

namespace ECoffee.Domain.Entities
{
    public class Product : BaseEntity
    {
        public Product()
        {
            Categories = new HashSet<Category>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UnitsInStock { get; set; }
        public float Price { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
