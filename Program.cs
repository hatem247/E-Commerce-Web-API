

using Holistic_Mission.Data;
using Holistic_Mission.Repository.CustomerRepo;
using Holistic_Mission.Repository.OrderRepo;
using Holistic_Mission.Repository.ProductRepo;
using Holistic_Mission.Repository.ShoppingCartRepo;
using Microsoft.EntityFrameworkCore;
using System;

namespace Holistic_Mission
{
    public class Program
    {
        //upload try in git
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
           builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<ICustomerRepo, CustomerRepo>();
            builder.Services.AddScoped<IProductRepo, ProductRepo>();
            builder.Services.AddScoped<IShoppingCartRepo, ShoppingCartRepo>();

            var app = builder.Build();
            
         

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
