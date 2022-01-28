using Microsoft.AspNetCore.Mvc;
using System.Device.Gpio;
using Iot.Device.Gpio;
using PoolController.WebAPI.Services;

namespace PoolController.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController : ControllerBase
    {
        static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        readonly ILogger<MainController> _logger;
        readonly IGpioService _gpioService;

        public MainController(ILogger<MainController> logger, IGpioService gpioService)
        {
            _logger = logger;
            _gpioService = gpioService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}