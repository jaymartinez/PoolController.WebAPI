using Microsoft.AspNetCore.Mvc;
using System.Device.Gpio;
using Iot.Device.Gpio;
using PoolController.WebAPI.Services;
using PoolController.WebAPI.Models;

namespace PoolController.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController : ControllerBase
    {
        readonly ILogger<MainController> _logger;
        readonly IGpioService _gpioService;
        readonly IAppRepository _appRepository;

        public MainController(
            ILogger<MainController> logger, 
            IGpioService gpioService,
            IAppRepository appRepository)
        {
            _logger = logger;
            _gpioService = gpioService;
            _appRepository = appRepository;
        }

        [HttpGet(Name = "GetAllStatuses")]
        public IEnumerable<PiPin> Get()
        {
            _logger.LogInformation("GETTING ALL STATUSES"); 
            return _appRepository.AllPins.ToArray();
        }
    }
}