using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Texter.Domain.Models;
using Texter.Infrastructure;

namespace Texter.Api.Controllers;

[ApiController]
[Route("users")]
public class UserController(
    AppDbContext dbContext
) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetAll()
    {
        IQueryable<User> users = dbContext.Users;

        var i = users.Select(x => x.Id).Contains(1);
        var i2 = users.Select(x => x.Id).Contains(2);

        return Ok(users);
    }


}
