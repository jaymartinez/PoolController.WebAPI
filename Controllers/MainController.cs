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

            var pinCount = _appRepository.AllModels.Count();

            var now = DateTime.Now.ToString(@"%h\:mm\:ss");
            _logger.LogInformation($"[{now}] MainController constructed, PINS INITIALIZED at this point is {pinCount}");
        }

        [HttpGet("status")]
        public ApiResult<List<PiPin>> GetAllStatuses()
        {
            var now = DateTime.Now.ToString(@"%h\:mm\:ss");
            _logger.LogInformation(new EventId(1), $"[{now}] GETTING ALL EQUIPMENT OBJECTS");

            var result = new ApiResult<List<PiPin>>();
            try
            {
                var allPins = _gpioService.GetAllStatuses().ToList();
                result.Data = allPins;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                result.Messages.Add(ex.Message);
            }

            return result;
        }

        [HttpGet("status/{type:int}")]
        public ApiResult<PiPin> GetStatus(PinType type)
        {
            var now = DateTime.Now.ToString(@"%h\:mm\:ss");
            _logger.LogInformation(new EventId(2), $"[{now}] GETTING PIN {type} status");

            switch (type)
            {
                case PinType.PoolLight:
                case PinType.PoolPump:
                    return new ApiResult<PiPin>(_gpioService.GetPool());
                case PinType.SpaLight:
                case PinType.SpaPump:
                    return new ApiResult<PiPin>(_gpioService.GetSpa());
                case PinType.BoosterPump:
                    return new ApiResult<PiPin>(_gpioService.GetBooster());
                case PinType.GroundLights:
                    return new ApiResult<PiPin>(_gpioService.GetGroundLights());
                case PinType.Heater:
                    return new ApiResult<PiPin>(_gpioService.GetHeater());
            }

            var result = new ApiResult<PiPin>();
            result.Messages.Add($"[GetStatus] for pinType {type} failed with unknown error");
            return result;
        }
    }
}