using APIFarm.Model;
using Microsoft.EntityFrameworkCore;

namespace APIFarm
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            try
            {
                // Add services to the container.
                builder.Services.AddDbContext<FarmDbContext>(options => options.UseSqlServer(Environment.GetEnvironmentVariable("SQL_CONNECTION_STRING")));

                builder.Services.AddControllers();
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen();

                var app = builder.Build();

                app.UseSwagger();
                app.UseSwaggerUI();

                app.UseHttpsRedirection();
                app.UseAuthorization();

                app.MapControllers();

                app.Run(); // Start the application
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred during startup: {ex.Message}");
                throw; // Rethrow the exception to prevent silent failures
            }
        }
    }
}
