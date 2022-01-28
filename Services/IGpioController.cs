using System.Device.Gpio;

namespace PoolController.WebAPI.Services
{
    public interface IGpioController
    {
        void Write(int pinNumber, PinValue pinValue);
        PinValue Read(int pinNumber);
    }
}
