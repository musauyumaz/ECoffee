using ECoffee.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ECoffee.Persistence.Contexts
{
    public class ECoffeeDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public ECoffeeDbContext(DbContextOptions options) : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }


    }
}
