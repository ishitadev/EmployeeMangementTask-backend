using DepartmentAPI.Services;
using EmployeeAPI.Data;
using EmployeeAPI.Helper;
using EmployeeAPI.Interfaces.Repository;
using EmployeeAPI.Interfaces.Services;
using EmployeeAPI.Repository;
using EmployeeAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<DataContext>(options =>
            {
                //builder.cofiguration and not just configuration
                //options.UseInMemoryDatabase("EmployeeDb");
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
            }, ServiceLifetime.Transient);
            // Add services to the container.
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowLocalhost",
                    builder => builder.WithOrigins("https://localhost:7241") // Add your front-end URL
                                      .AllowAnyHeader()
                                      .AllowAnyMethod());
            });
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //builder.cor
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("AllowLocalhost");
            app.MapControllers();

            app.Run();
        }
    }
}
