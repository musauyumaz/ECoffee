using ECoffee.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECoffee.Persistence.EntitiesMapping
{
    public class CustomerMapping : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(c=>c.Name).HasMaxLength(25);
            builder.Property(c=>c.Surname).HasMaxLength(25);
            builder.Property(c=>c.Email).HasMaxLength(100);
        }

    }
}
