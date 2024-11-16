using Microsoft.AspNetCore.Mvc;
using Texter.Api.Contracts;
using Texter.App.Services;

namespace Texter.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController(IAuthenticationService authenticationService) : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> Register(RegisterRequest registerRequest)
    {
        var nickname = registerRequest.nickname;
        var registerResult = await authenticationService.Register(nickname);
        return registerResult.Match<IActionResult>(
            registered =>
            {
                if (!registered) throw new Exception();
                Response.Cookies.Append("nickname", nickname, new()
                {
                    Expires = DateTime.UtcNow.AddMinutes(10)
                });
                return Ok();
            },
            nameTakenError => BadRequest(nameTakenError)
        );
    }
}