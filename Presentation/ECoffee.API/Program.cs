using ECoffee.Application;
using ECoffee.Infrastructure;
using ECoffee.Persistence;
using ECoffee.Persistence.Contexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ECoffee.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<ECoffeeDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("MsSQL"));
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            builder.Services.AddPersistenceServices();
            builder.Services.AddApplicationServices();
            builder.Services.AddInfrastructureServices();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            //builder.Services.AddCors(options => options.AddDefaultPolicy(policy=> policy.WithOrigins("https://localhost:7070", "http://localhost:5500").AllowAnyHeader().AllowAnyMethod().AllowCredentials()));

            //builder.Services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //    .AddJwtBearer(options =>
            //    {
            //        options.TokenValidationParameters = new()
            //        {
            //            ValidateAudience = true,
            //            ValidateIssuer = true,
            //            ValidateIssuerSigningKey = true,
            //            ValidateLifetime = true,

            //            ValidAudience = builder.Configuration["JWT:Audience"],
            //            ValidIssuer = builder.Configuration["JWT:Issuer"],
            //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:SigningKey"])),
            //        };
            //    });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            //app.UseCors();
            app.UseHttpsRedirection();

            //app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}