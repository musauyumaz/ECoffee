using Microsoft.AspNetCore.Identity;

namespace ECoffee.Domain.Entities.Identity
{
    public class AppRole : IdentityRole<int>
    {
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
