using Microsoft.AspNetCore.Mvc;
using System;
using WeatherApi.Models;

namespace WeatherApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet]
        public WeatherForecast Get()
        {
            var rng = new Random();
            WeatherForecast weatherForecast = new()
            {
                Date = DateTime.Now,
                TemperatureC = rng.Next(-25, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            };
            return weatherForecast;
        }
    }
}
