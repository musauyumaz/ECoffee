using ECoffee.Application.Repositories.Categories;
using ECoffee.Application.Repositories.Customers;
using ECoffee.Application.Repositories.Products;
using ECoffee.Application.Services;
using ECoffee.Persistence.Configurations;
using ECoffee.Persistence.Contexts;
using ECoffee.Persistence.Repositories.Categories;
using ECoffee.Persistence.Repositories.Customers;
using ECoffee.Persistence.Repositories.Products;
using ECoffee.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ECoffee.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<ECoffeeDbContext>(options => options.UseSqlServer(Configuration.ConnectionString));

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICustomerService, CustomerService>();


            services.AddScoped<ICategoryQueryRepository, CategoryQueryRepository>();
            services.AddScoped<ICategoryCommandRepository, CategoryCommandRepository>();
            services.AddScoped<IProductCommandRepository, ProductCommandRepository>();
            services.AddScoped<IProductCommandRepository, ProductCommandRepository>();
            services.AddScoped<ICustomerCommandRepository,CustomerCommandRepository>();
            services.AddScoped<ICustomerQueryRepository,CustomerQueryRepository>();

        }
    }
}
