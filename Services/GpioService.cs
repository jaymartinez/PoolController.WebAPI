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
            return _appRepository.AllModels;
        }

        public LightModel SaveSpaLightMode(LightModeType lightMode)
        {
            try
            {
                _appRepository.Spa.Light.PreviousMode = _appRepository.Spa.Light.CurrentMode;
                _appRepository.Spa.Light.CurrentMode = lightMode;
                return _appRepository.Spa.Light;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public LightModel SavePoolLightMode(LightModeType lightMode)
        {
            try
            {
                _appRepository.Pool.Light.PreviousMode = _appRepository.Pool.Light.CurrentMode;
                _appRepository.Pool.Light.CurrentMode = lightMode;
                return _appRepository.Pool.Light;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public bool Toggle(PinType pinType)
        {
            try
            {
                switch (pinType)
                {
                    case PinType.PoolPump:
                        // They should both be the same but just read one then toggle both
                        if (Read(Pins.PoolPump_1) == PinValue.High)
                        {
                            _appRepository.Pool.PinValue = Write(Pins.PoolPump_1, PinValue.Low);
                            _appRepository.Pool.PinValue = Write(Pins.PoolPump_2, PinValue.Low);
                            _appRepository.Pool.DateDeactivated = DateTime.Now;
                        }
                        else
                        {
                            _appRepository.Pool.PinValue = Write(Pins.PoolPump_1, PinValue.High);
                            _appRepository.Pool.PinValue = Write(Pins.PoolPump_2, PinValue.High);
                            _appRepository.Pool.DateActivated = DateTime.Now;
                        }

                        break;
                    case PinType.SpaPump:
                        if (Read(Pins.SpaPump_1) == PinValue.High)
                        {
                            _appRepository.Spa.PinValue = Write(Pins.SpaPump_1, PinValue.Low);
                            _appRepository.Spa.PinValue = Write(Pins.SpaPump_2, PinValue.Low);
                            _appRepository.Spa.DateDeactivated = DateTime.Now;
                        }
                        else
                        {
                            _appRepository.Spa.PinValue = Write(Pins.SpaPump_1, PinValue.High);
                            _appRepository.Spa.PinValue = Write(Pins.SpaPump_2, PinValue.High);
                            _appRepository.Spa.DateActivated = DateTime.Now;
                        }

                        break;

                    case PinType.BoosterPump:
                        if (Read(Pins.BoosterPump_1) == PinValue.High)
                        {
                            _appRepository.Booster.PinValue = Write(Pins.BoosterPump_1, PinValue.Low);
                            _appRepository.Booster.PinValue = Write(Pins.BoosterPump_2, PinValue.Low);
                            _appRepository.Booster.DateDeactivated = DateTime.Now;
                        }
                        else
                        {
                            _appRepository.Booster.PinValue = Write(Pins.BoosterPump_1, PinValue.High);
                            _appRepository.Booster.PinValue = Write(Pins.BoosterPump_2, PinValue.High);
                            _appRepository.Booster.DateActivated = DateTime.Now;
                        }
                        break;
                    case PinType.PoolLight:
                        if (Read(Pins.PoolLight) == PinValue.High)
                        {
                            _appRepository.Pool.Light.PinValue = Write(Pins.PoolLight, PinValue.Low);
                            _appRepository.Pool.Light.DateDeactivated = DateTime.Now;
                        }
                        else
                        {
                            _appRepository.Pool.Light.PinValue = Write(Pins.PoolLight, PinValue.High);
                            _appRepository.Pool.Light.DateActivated = DateTime.Now;
                        }
                        break;
                    case PinType.SpaLight:
                        if (Read(Pins.SpaLight) == PinValue.High)
                        {
                            _appRepository.Spa.Light.PinValue = Write(Pins.SpaLight, PinValue.Low);
                            _appRepository.Spa.Light.DateDeactivated = DateTime.Now;
                        }
                        else
                        {
                            _appRepository.Spa.Light.PinValue = Write(Pins.SpaLight, PinValue.High);
                            _appRepository.Spa.Light.DateActivated = DateTime.Now;
                        }
                        break;
                    case PinType.Heater:
                        if (Read(Pins.Heater) == PinValue.High)
                        {
                            _appRepository.Heater.PinValue = Write(Pins.Heater, PinValue.Low);
                            _appRepository.Heater.DateDeactivated = DateTime.Now;
                        }
                        else
                        {
                            _appRepository.Heater.PinValue = Write(Pins.Heater, PinValue.High);
                            _appRepository.Heater.DateActivated = DateTime.Now;
                        }
                        break;
                    case PinType.GroundLights:
                        if (Read(Pins.GroundLights) == PinValue.High)
                        {
                            _appRepository.GroundLights.PinValue = Write(Pins.GroundLights, PinValue.Low);
                            _appRepository.GroundLights.DateDeactivated = DateTime.Now;
                        }
                        else
                        {
                            _appRepository.GroundLights.PinValue = Write(Pins.GroundLights, PinValue.High);
                            _appRepository.GroundLights.DateActivated = DateTime.Now;
                        }
                        break;
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }


        public PoolModel GetPool()
        {
            return _appRepository.Pool;
        }

        public SpaModel GetSpa()
        {
            return _appRepository.Spa;
        }

        public BoosterPumpModel GetBooster()
        {
            return _appRepository.Booster;
        }

        public LightModel GetGroundLights()
        {
            return _appRepository.GroundLights;
        }

        public HeaterModel GetHeater()
        {
            return _appRepository.Heater;
        }

        public PoolModel SavePool(PoolModel poolModel)
        {
            _appRepository.Pool.Save(poolModel, true);
            return _appRepository.Pool;
        }

        public SpaModel SaveSpa(SpaModel spaModel)
        {
            _appRepository.Spa.Save(spaModel, true);
            return _appRepository.Spa;
        }

        public HeaterModel SaveHeater(HeaterModel heaterModel)
        {
            _appRepository.Heater.Save(heaterModel);
            return _appRepository.Heater;
        }

        public BoosterPumpModel SaveBooster(BoosterPumpModel boosterPumpModel)
        {
            _appRepository.Booster.Save(boosterPumpModel, true);
            return _appRepository.Booster;
        }

        public LightModel SaveGroundLights(LightModel groundLightsModel)
        {
            _appRepository.GroundLights.Save(groundLightsModel, true);
            return _appRepository.GroundLights;
        }

        /// <summary>
        /// Read the current value of a pin
        /// </summary>
        /// <param name="pinNumber">The pin to read the value of</param>
        /// <returns></returns>
        public PinValue Read(int pinNumber)
        {
            return _gpio.Read(pinNumber);
        }

        /// <summary>
        /// Writes the value to the pin and returns the final state of the pin
        /// </summary>
        /// <param name="pinNumber">Pin number to write to</param>
        /// <param name="valueToWrite">The value to write, high or low</param>
        /// <returns>The final pin value if the write was successful</returns>
        PinValue Write(int pinNumber, PinValue valueToWrite)
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

    }
}

