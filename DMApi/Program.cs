using DMApi.Services;
using DMApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using DMApi.Repositories;

namespace DMApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");



            // Configure your DbContext with the retrieved connection string
            builder.Services.AddDbContext<UnitDB>(options =>
                options.UseSqlServer(connectionString));

            // Add services to the container.

            builder.Services.AddControllers();
            //builder.Services.AddScoped<IUnitService, UnitService>();
            builder.Services.AddScoped<IUnitRepsitory, UnitRepository>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());


            app.MapControllers();

            app.Run();
        }
    }
}
