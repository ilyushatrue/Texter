
using Texter.Api.Middlewares;
using Texter.Infrastructure;

namespace Texter.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddScoped<ExceptionHandlingMiddleware>();
        builder.Services.AddDbContext<AppDbContext>();
        builder.Services.AddCors(cors => cors.AddPolicy("localhost_cors", policy => policy
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
            .WithOrigins("http://localhost:4201", "http://localhost:4200")));
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDomainServices();
        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors("localhost_cors");
        app.UseMiddleware<ExceptionHandlingMiddleware>();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
