using Microsoft.AspNetCore.Mvc;

namespace WSventas.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        List<WeatherForecast> lst = new List<WeatherForecast>();
        lst.Add( new WeatherForecast() {id =5, Name="Nestor"});
        lst.Add( new WeatherForecast() {id =1, Name="Adonai"});
        return lst;
    }
}
