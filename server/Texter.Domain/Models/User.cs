using Texter.Domain.Models.Base;

namespace Texter.Domain.Models;

public class User : BaseEntity
{
    public string Name { get; set; } = null!;
}
