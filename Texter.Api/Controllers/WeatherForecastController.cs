using Microsoft.AspNetCore.Mvc;

namespace Texter.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    [HttpGet(Name = "GetWeatherForecast")]
    public IActionResult Get()
    {
        return Ok("ok");
    }
}
