
using Texter.Api.Middlewares;
using Texter.App.Hubs;
using Texter.Infrastructure;

namespace Texter.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddScoped<ExceptionHandlingMiddleware>();
        builder.Services.AddDbContext<AppDbContext>();
        var localhostCorsName = "localhost_cors";
        builder.Services.AddCors(cors => cors.AddPolicy(localhostCorsName, policy => policy
            .WithOrigins("http://localhost:4201", "http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()));
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDomainServices();
        builder.Services.AddSignalR();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors(localhostCorsName);
        app.MapHub<UserHub>("/user-hub");
        app.UseMiddleware<ExceptionHandlingMiddleware>();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}
