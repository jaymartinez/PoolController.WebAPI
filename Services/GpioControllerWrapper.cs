using System.Device.Gpio;

namespace PoolController.WebAPI.Services
{
    public class GpioControllerWrapper : GpioController, IGpioController
    {
        void IGpioController.Write(int pinNumber, PinValue value)
        {
            base.Write(pinNumber, value);
        }

        PinValue IGpioController.Read(int pinNumber)
        {
            return base.Read(pinNumber);
        }
    }
}
