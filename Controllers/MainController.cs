using Microsoft.AspNetCore.Mvc;
using System.Device.Gpio;
using Iot.Device.Gpio;
using PoolController.WebAPI.Services;
using PoolController.WebAPI.Models;

namespace PoolController.WebAPI.Controllers
{
    [ApiController]
    [Route("api/mobile")]
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

        //[HttpGet("GetAllStatuses")]
        [HttpGet, Route("status/all")]
        public IEnumerable<PiPin> GetAllStatuses()
        {
            _logger.LogInformation("GETTING ALL STATUSES"); 
            return _appRepository.AllPins.ToArray();
        }

        [HttpGet("status/{type:int}")]
        public PiPin GetPinStatus(PinType pinType)
        {
            _logger.LogInformation($"GETTING PIN {pinType} status");
            return _gpioService.GetEquipmentStatus(pinType);
        }
    }
}