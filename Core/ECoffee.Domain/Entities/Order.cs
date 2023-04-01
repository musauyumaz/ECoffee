using ECoffee.Domain.Entities.Common;

namespace ECoffee.Domain.Entities
{
    public class Order : BaseEntity
    {
        public int CustomerId { get; set; }
        public string Note { get; set; }

        public Customer Customer { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}
