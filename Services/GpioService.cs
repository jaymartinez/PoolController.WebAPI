using Iot.Device.Gpio.Drivers;
using PoolController.WebAPI.Models;
using System.Device.Gpio;

namespace PoolController.WebAPI.Services
{
    public class GpioService : IGpioService
    {
        readonly ILogger<GpioService> _logger;
        readonly IGpioController _gpio;

        public GpioService(ILogger<GpioService> logger, IGpioController gpioController)
        {
            _logger = logger;
            _gpio = gpioController;
        }

        public IEnumerable<PiPin> GetAllStatuses()
        {
            return new List<PiPin>
            {
                new PiPin { PinType = PinType.PoolPump, PinState = Read(Pins.PoolPump_1) },
                new PiPin { PinType = PinType.SpaPump, PinState = Read(Pins.SpaPump_1) },
                new PiPin { PinType = PinType.BoosterPump, PinState = Read(Pins.BoosterPump_1) },
                new PiPin { PinType = PinType.PoolLight, PinState = Read(Pins.PoolLight) },
                new PiPin { PinType = PinType.SpaLight, PinState = Read(Pins.SpaLight) },
                new PiPin { PinType = PinType.GroundLights, PinState = Read(Pins.GroundLights) },
                new PiPin { PinType = PinType.Heater, PinState = Read(Pins.Heater) }
            };
        }

        public PinValue Read(int pinNumber)
        {
            return _gpio.Read(pinNumber);
        }

        public LightModel SaveLightMode(LightType lightType)
        {
            try
            {
                // TODO
                return new LightModel();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public PiPin Toggle(PinType pinType)
        {
            var pin = new PiPin
            {
                PinType = pinType
            };

            switch (pinType)
            {
                case PinType.PoolPump:
                    // They should both be the same but just read one then toggle both
                    if (Read(Pins.PoolPump_1) == PinValue.High)
                    {
                        pin.PinState = Write(Pins.PoolPump_1, PinValue.Low);
                        pin.PinState = Write(Pins.PoolPump_2, PinValue.Low);
                    }
                    else
                    {
                        pin.PinState = Write(Pins.PoolPump_1, PinValue.High);
                        pin.PinState = Write(Pins.PoolPump_2, PinValue.High);
                    }

                    break;
                case PinType.SpaPump:
                    if (Read(Pins.SpaPump_1) == PinValue.High)
                    {
                        pin.PinState = Write(Pins.SpaPump_1, PinValue.Low);
                        pin.PinState = Write(Pins.SpaPump_2, PinValue.Low);
                    }
                    else
                    {
                        pin.PinState = Write(Pins.SpaPump_1, PinValue.High);
                        pin.PinState = Write(Pins.SpaPump_2, PinValue.High);
                    }

                    break;

                case PinType.BoosterPump:
                    if (Read(Pins.BoosterPump_1) == PinValue.High)
                    {
                        pin.PinState = Write(Pins.BoosterPump_1, PinValue.Low);
                        pin.PinState = Write(Pins.BoosterPump_2, PinValue.Low);
                    }
                    else
                    {
                        pin.PinState = Write(Pins.BoosterPump_1, PinValue.High);
                        pin.PinState = Write(Pins.BoosterPump_2, PinValue.High);
                    }
                    break;
                case PinType.PoolLight:
                    if (Read(Pins.PoolLight) == PinValue.High)
                    {
                        pin.PinState = Write(Pins.PoolLight, PinValue.Low);
                    }
                    else
                    {
                        pin.PinState = Write(Pins.PoolLight, PinValue.High);
                    }
                    break;
                case PinType.SpaLight:
                    if (Read(Pins.SpaLight) == PinValue.High)
                    {
                        pin.PinState = Write(Pins.SpaLight, PinValue.Low);
                    }
                    else
                    {
                        pin.PinState = Write(Pins.SpaLight, PinValue.High);
                    }
                    break;
                case PinType.Heater:
                    if (Read(Pins.Heater) == PinValue.High)
                    {
                        pin.PinState = Write(Pins.Heater, PinValue.Low);
                    }
                    else
                    {
                        pin.PinState = Write(Pins.Heater, PinValue.High);
                    }
                    break;
                case PinType.GroundLights:
                    if (Read(Pins.GroundLights) == PinValue.High)
                    {
                        pin.PinState = Write(Pins.GroundLights, PinValue.Low);
                    }
                    else
                    {
                        pin.PinState = Write(Pins.GroundLights, PinValue.High);
                    }
                    break;
            }

            if (pin.PinState == PinValue.High)
            {
                pin.DateActivated = DateTime.Now;
            }
            else
            {
                pin.DateDeactivated = DateTime.Now;
            }
           
            return pin;
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
    }
}
