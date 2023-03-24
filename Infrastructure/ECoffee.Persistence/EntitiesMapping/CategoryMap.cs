using ECoffee.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECoffee.Persistence.EntitiesMapping
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c=>c.Name).HasMaxLength(50);
            builder.Property(c=>c.Description).HasMaxLength(300);
        }
    }
}
