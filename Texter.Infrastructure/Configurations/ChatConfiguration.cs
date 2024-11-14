using Texter.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Texter.Infrastructure.Configurations;

public class ChatConfiguration : IEntityTypeConfiguration<Chat>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Chat> builder)
    {
    }
}