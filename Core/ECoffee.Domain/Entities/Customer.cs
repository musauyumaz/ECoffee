using ECoffee.Domain.Entities.Common;

namespace ECoffee.Domain.Entities
{
    public  class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
