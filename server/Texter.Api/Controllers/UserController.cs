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
        var users = await dbContext.Users.ToListAsync();
        return Ok(users);
    }


}
