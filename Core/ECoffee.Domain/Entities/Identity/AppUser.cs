using Microsoft.AspNetCore.Identity;

namespace ECoffee.Domain.Entities.Identity
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
