using Microsoft.EntityFrameworkCore;
using OneOf;
using Texter.App.Services;
using Texter.Domain.Errors;
using Texter.Domain.Errors.Base;

namespace Texter.Infrastructure.Services;

public class AuthenticationService(AppDbContext dbContext) : IAuthenticationService
{
    public async Task<OneOf<bool, ErrorList>> Register(string nickname)
    {
        if (await dbContext.Users.AnyAsync(u => u.Name == nickname.Trim()))
        {
            return new ErrorList(){
                new NameTakenError()
            };
        }
        dbContext.Users.Add(new()
        {
            Name = nickname
        });

        var affectedCount = await dbContext.SaveChangesAsync();
        return affectedCount > 0;
    }

}