using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Texter.Domain.Models;

namespace Texter.Infrastructure;

public class AppDbContext(
    IConfiguration configuration
) : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = configuration.GetConnectionString("DB");
        optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
        optionsBuilder.UseNpgsql(connectionString).EnableSensitiveDataLogging();
    }

    public required DbSet<User> Users { get; set; }
    public required DbSet<Message> Messages { get; set; }
    public required DbSet<Chat> Chats { get; set; }
}