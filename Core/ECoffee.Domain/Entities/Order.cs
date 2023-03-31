using ECoffee.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECoffee.Domain.Entities
{
    public class Order:BaseEntity
    {
        public Customer Customer { get; set; }
        public List<Product> Products { get; set; }
        public double TotalPrice { get; set; }
    }
}
