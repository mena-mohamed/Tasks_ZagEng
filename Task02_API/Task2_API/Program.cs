
using Microsoft.EntityFrameworkCore;
using Task2_API.Data;
using Task2_API.Filters;
using Task2_API.Middlewares;
using Task2_API.Services;

namespace Task2_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IJobService, JobService>();
            builder.Services.AddScoped<ValidateJobFilter>();

            // Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // 1. UseExceptionHandler — placed FIRST so it catches errors from ALL other middleware
            app.UseExceptionHandler("/error");

            // 2. Custom RequestLogger — placed early so it logs EVERY request
            app.UseMiddleware<RequestLoggerMiddleware>();

            // 3. UseRouting — must come before UseAuthorization
            app.UseRouting();

            // 4. UseAuthorization — placed after UseRouting
            app.UseAuthorization();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapControllers();

            app.Run();


        }
    }
}
