using System.Device.Gpio;
using System.Runtime.Serialization;

namespace PoolController.WebAPI.Models
{
    [Serializable]
    public class PiPin
    {
        public PiPin() { }

        public PiPin(int gpio1, PinType type, int? gpio2 = null)
        {
            GpioPin1 = gpio1;
            Type = type;
            GpioPin2 = gpio2;
        }

        /// <summary>
        /// Primary GPIO pin
        /// </summary>
        [DataMember(IsRequired = true)]
        public int GpioPin1 { get; } = -1;

        /// <summary>
        /// If applicable, the secondary GPIO pin. Some devices like the pool pump operate
        /// on two 110v relays.
        /// </summary>
        [DataMember(IsRequired = false)]
        public int? GpioPin2 { get; } = null;

        /// <summary>
        /// The <see cref="DateTime"/> the pin was set to high
        /// </summary>
        [DataMember(IsRequired = false)]
        public DateTime? DateActivated { get; set; } = null;

        /// <summary>
        /// The <see cref="DateTime"/> the pin was set to low
        /// </summary>
        [DataMember(IsRequired = false)]
        public DateTime? DateDeactivated { get; set; } = null;

        /// <summary>
        /// State of the pin, either High or Low
        /// </summary>
        [DataMember(IsRequired = true)]
        public PinValue PinValue { get; set; } = PinValue.Low;

        [DataMember(IsRequired = true)]
        public PinType Type { get; } = PinType.Undefined;
    }
}
