using Microsoft.AspNetCore.Mvc;
using System.Device.Gpio;
using Iot.Device.Gpio;

namespace PoolController.WebAPI.Controllers
{
    /*
            app.set('port', process.env.PORT || 9000);
            app.get('/ping', _.bind(controller.ping, controller));
            app.get('/poolPump', _.bind(controller.togglePoolPump, controller));
            app.get('/boosterPump', _.bind(controller.toggleBoosterPump, controller));
            app.get('/spaPump', _.bind(controller.toggleSpaPump, controller));
            app.get('/spaLight', _.bind(controller.toggleSpaLight, controller));
            app.get('/poolLight', _.bind(controller.togglePoolLight, controller));
            app.get('/groundLights', _.bind(controller.toggleGroundLights, controller));
            app.get('/heater', _.bind(controller.toggleHeater, controller));
            app.get('/setSchedule', _.bind(controller.setSchedule, controller));
            app.get('/getSchedule', _.bind(controller.getSchedule, controller));
            app.get('/setPoolLightSchedule', _.bind(controller.setPoolLightSchedule, controller));
            app.get('/getPoolLightSchedule', _.bind(controller.getPoolLightSchedule, controller));
            app.get('/setGroundLightSchedule', _.bind(controller.setGroundLightSchedule, controller));
            app.get('/getGroundLightSchedule', _.bind(controller.getGroundLightSchedule, controller));
            app.get('/setSpaLightSchedule', _.bind(controller.setSpaLightSchedule, controller));
            app.get('/getSpaLightSchedule', _.bind(controller.getSpaLightSchedule, controller));
            app.get('/setBoosterSchedule', _.bind(controller.setBoosterSchedule, controller));
            app.get('/getBoosterSchedule', _.bind(controller.getBoosterSchedule, controller));
            app.get('/status', _.bind(controller.pinStatus, controller));
            app.get('/allStatuses', _.bind(controller.allStatuses, controller));
            app.get('/toggleMasterSwitch', _.bind(controller.toggleMasterSwitch, controller));
            app.get('/toggleIncludeBoosterSwitch', _.bind(controller.toggleIncludeBoosterSwitch, controller));
            app.get('/masterSwitchStatus', _.bind(controller.masterSwitchStatus, controller));
            app.get('/savePoolLightMode', _.bind(controller.savePoolLightMode, controller));
            app.get('/getPoolLightMode', _.bind(controller.getPoolLightMode, controller));
            app.get('/saveSpaLightMode', _.bind(controller.saveSpaLightMode, controller));
            app.get('/getSpaLightMode', _.bind(controller.getSpaLightMode, controller));
    */
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
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