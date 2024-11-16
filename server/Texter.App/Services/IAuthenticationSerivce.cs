using OneOf;
using Texter.Domain.Errors.Base;

namespace Texter.App.Services;

public interface IAuthenticationService
{
    Task<OneOf<bool, ErrorList>> Register(string nickname);
}
