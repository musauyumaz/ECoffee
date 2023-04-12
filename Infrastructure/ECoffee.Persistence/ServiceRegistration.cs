using ECoffee.Application.Abstractions.Repositories.Categories;
using ECoffee.Application.Abstractions.Repositories.Customers;
using ECoffee.Application.Abstractions.Repositories.Orders;
using ECoffee.Application.Abstractions.Repositories.Products;
using ECoffee.Application.Abstractions.Services;
using ECoffee.Persistence.Configurations;
using ECoffee.Persistence.Contexts;
using ECoffee.Persistence.Repositories.Categories;
using ECoffee.Persistence.Repositories.Customers;
using ECoffee.Persistence.Repositories.Orders;
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
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();


            services.AddScoped<ICategoryCommandRepository, CategoryCommandRepository>();
            services.AddScoped<ICategoryQueryRepository, CategoryQueryRepository>();
            services.AddScoped<IProductCommandRepository, ProductCommandRepository>();
            services.AddScoped<IProductQueryRepository, ProductQueryRepository>();
            services.AddScoped<ICustomerCommandRepository,CustomerCommandRepository>();
            services.AddScoped<ICustomerQueryRepository,CustomerQueryRepository>();
            services.AddScoped<IOrderCommandRepository, OrderCommandRepository>();
            services.AddScoped<IOrderQueryRepository, OrderQueryRepository>();

        }
    }
}
