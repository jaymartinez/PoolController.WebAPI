using Iot.Device.Gpio.Drivers;
using PoolController.WebAPI.Models;
using System.Device.Gpio;

namespace PoolController.WebAPI.Services
{
    public class GpioService : IGpioService
    {
        readonly ILogger<GpioService> _logger;
        readonly IGpioController _gpio;
        readonly IAppRepository _appRepository;

        public GpioService(ILogger<GpioService> logger, IGpioController gpioController, IAppRepository repository)
        {
            _logger = logger;
            _gpio = gpioController;
            _appRepository = repository;
        }

        public IEnumerable<PiPin> GetAllStatuses()
        {
            return new List<PiPin>
            {
                _appRepository.PoolPump,
                _appRepository.SpaPump,
                _appRepository.BoosterPump,
                _appRepository.PoolLight,
                _appRepository.SpaLight,
                _appRepository.GroundLights,
                _appRepository.Heater,
            };
        }

        public EquipmentSchedule GetSchedule(ScheduleType scheduleType)
        {
            switch (scheduleType)
            {
                case ScheduleType.Booster:
                    return _appRepository.BoosterPumpSchedule;
                case ScheduleType.Pool:
                    return _appRepository.PoolPumpSchedule;
                case ScheduleType.PoolLight:
                    return _appRepository.PoolLightSchedule;
                case ScheduleType.SpaLight:
                    return _appRepository.SpaLightSchedule;
                default:
                    break;
            }

            throw new NotSupportedException();
        }

        public LightModel SaveLightMode(LightModeType mode, LightType lightType)
        {
            try
            {
                switch (lightType)
                {
                    case LightType.Pool:
                        // Before saving, set the current pool light mode as the previous one
                        _appRepository.PreviousPoolLightMode = _appRepository.PoolLightMode;
                        _appRepository.PoolLightMode = mode;
                        return new LightModel
                        {
                            CurrentMode = mode,
                            PreviousMode = _appRepository.PreviousPoolLightMode,
                            LightType = LightType.Pool
                        };
                    case LightType.Spa:
                        _appRepository.PreviousSpaLightMode = _appRepository.SpaLightMode;
                        _appRepository.SpaLightMode = mode;
                        return new LightModel
                        {
                            CurrentMode = mode,
                            PreviousMode = _appRepository.PreviousSpaLightMode,
                            LightType = LightType.Spa
                        };
                    default:
                        throw new NotSupportedException($"The light type {lightType.ToLightTypeString()} is not supported");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public PiPin Toggle(PinType pinType)
        {
            var pin = _appRepository.AllPins.FirstOrDefault(_ => _.PinType == pinType);
            if (pin == null)
            {
                return new PiPin(pinType);
            }

            switch (pinType)
            {
                case PinType.PoolPump:
                    // They should both be the same but just read one then toggle both
                    if (Read(Pins.PoolPump_1) == PinValue.High)
                    {
                        pin.PinValue = Write(Pins.PoolPump_1, PinValue.Low);
                        pin.PinValue = Write(Pins.PoolPump_2, PinValue.Low);
                    }
                    else
                    {
                        pin.PinValue = Write(Pins.PoolPump_1, PinValue.High);
                        pin.PinValue = Write(Pins.PoolPump_2, PinValue.High);
                    }

                    break;
                case PinType.SpaPump:
                    if (Read(Pins.SpaPump_1) == PinValue.High)
                    {
                        pin.PinValue = Write(Pins.SpaPump_1, PinValue.Low);
                        pin.PinValue = Write(Pins.SpaPump_2, PinValue.Low);
                    }
                    else
                    {
                        pin.PinValue = Write(Pins.SpaPump_1, PinValue.High);
                        pin.PinValue = Write(Pins.SpaPump_2, PinValue.High);
                    }

                    break;

                case PinType.BoosterPump:
                    if (Read(Pins.BoosterPump_1) == PinValue.High)
                    {
                        pin.PinValue = Write(Pins.BoosterPump_1, PinValue.Low);
                        pin.PinValue = Write(Pins.BoosterPump_2, PinValue.Low);
                    }
                    else
                    {
                        pin.PinValue = Write(Pins.BoosterPump_1, PinValue.High);
                        pin.PinValue = Write(Pins.BoosterPump_2, PinValue.High);
                    }
                    break;
                case PinType.PoolLight:
                    if (Read(Pins.PoolLight) == PinValue.High)
                    {
                        pin.PinValue = Write(Pins.PoolLight, PinValue.Low);
                    }
                    else
                    {
                        pin.PinValue = Write(Pins.PoolLight, PinValue.High);
                    }
                    break;
                case PinType.SpaLight:
                    if (Read(Pins.SpaLight) == PinValue.High)
                    {
                        pin.PinValue = Write(Pins.SpaLight, PinValue.Low);
                    }
                    else
                    {
                        pin.PinValue = Write(Pins.SpaLight, PinValue.High);
                    }
                    break;
                case PinType.Heater:
                    if (Read(Pins.Heater) == PinValue.High)
                    {
                        pin.PinValue = Write(Pins.Heater, PinValue.Low);
                    }
                    else
                    {
                        pin.PinValue = Write(Pins.Heater, PinValue.High);
                    }
                    break;
                case PinType.GroundLights:
                    if (Read(Pins.GroundLights) == PinValue.High)
                    {
                        pin.PinValue = Write(Pins.GroundLights, PinValue.Low);
                    }
                    else
                    {
                        pin.PinValue = Write(Pins.GroundLights, PinValue.High);
                    }
                    break;
            }

            if (pin.PinValue == PinValue.High)
            {
                pin.DateActivated = DateTime.Now;
            }
            else
            {
                pin.DateDeactivated = DateTime.Now;
            }
           
            return pin;
        }

        public PinValue Read(int pinNumber)
        {
            return _gpio.Read(pinNumber);
        }

        public PinValue Write(int pinNumber, PinValue valueToWrite)
        {
            try
            {
                _gpio.Write(pinNumber, valueToWrite);
                return _gpio.Read(pinNumber);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public EquipmentSchedule SetSchedule(EquipmentSchedule schedule)
        {
            switch (schedule.Type)
            {
                case ScheduleType.Pool:
                    _appRepository.PoolPumpSchedule = schedule;
                    return GetSchedule(ScheduleType.Pool);
                case ScheduleType.Booster:
                    _appRepository.BoosterPumpSchedule = schedule;
                    return GetSchedule(ScheduleType.Booster);
                case ScheduleType.PoolLight:
                    _appRepository.PoolLightSchedule = schedule;
                    return GetSchedule(ScheduleType.PoolLight);
                case ScheduleType.SpaLight:
                    _appRepository.SpaLightSchedule = schedule;
                    return GetSchedule(ScheduleType.SpaLight);
            }

            throw new NotSupportedException();
        }

        public LightModel GetCurrentLightMode(LightType lightType)
        {
            switch (lightType)
            {
                case LightType.Pool:
                    return new LightModel
                    {
                        CurrentMode = _appRepository.PoolLightMode,
                        LightType = lightType,
                        PreviousMode = _appRepository.PreviousPoolLightMode
                    };
                case LightType.Spa:
                    return new LightModel
                    {
                        CurrentMode = _appRepository.SpaLightMode,
                        LightType = lightType,
                        PreviousMode = _appRepository.PreviousSpaLightMode
                    };
                default:
                    break;
            }

            throw new NotSupportedException();
        }

        public PiPin GetEquipmentStatus(PinType pinType)
        {
            return _appRepository.AllPins.FirstOrDefault(_ => _.PinType == pinType) ?? new PiPin();   
        }
    }
}

