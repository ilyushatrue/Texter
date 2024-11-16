using Texter.Domain.Errors.Base;

namespace Texter.Domain.Errors;

public class NameTakenError : Error
{
    public NameTakenError() : base(nameof(NameTakenError), "Sorry, that name is already in use") { }
}