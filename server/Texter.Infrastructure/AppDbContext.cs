using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Texter.Infrastructure;

public class AppDbContext(
    IConfiguration configuration
): DbContext{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("User Id=postgres;Host=localhost;Database=chat_db;Port=5432;Password=qwer1234;");
    }
}