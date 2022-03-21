using System.Device.Gpio;
using System.Runtime.Serialization;

namespace PoolController.WebAPI.Models
{
    [Serializable]
    public class PiPin
    {
        public PiPin() { }

        public PiPin (PinType type)
        {
            PinType = type;

            switch (type)
            {
                case PinType.PoolPump:
                    GpioPin1 = Pins.PoolPump_1;
                    GpioPin2 = Pins.PoolPump_2;
                    break;
                case PinType.SpaPump:
                    GpioPin1 = Pins.SpaPump_1;
                    GpioPin2 = Pins.SpaPump_2;
                    break;
                case PinType.BoosterPump:
                    GpioPin1 = Pins.BoosterPump_1;
                    GpioPin2 = Pins.BoosterPump_2;
                    break;
                case PinType.PoolLight:
                    GpioPin1 = Pins.PoolLight;
                    break;
                case PinType.SpaLight:
                    GpioPin1 = Pins.SpaLight;
                    break;
                case PinType.GroundLights:
                    GpioPin1 = Pins.GroundLights;
                    break;
                case PinType.Heater:
                    GpioPin1 = Pins.Heater;
                    break;
                default:
                    GpioPin1 = -1;
                    break;
            }

        }

        [DataMember]
        public int GpioPin1 { get; set; } = -1;

        [DataMember]
        public int? GpioPin2 { get; set; } = null;

        [DataMember]
        public PinType PinType { get; set; } = PinType.None;

        [DataMember]
        public DateTime? DateActivated { get; set; } = null;

        [DataMember]
        public DateTime? DateDeactivated { get; set; } = null;

        [DataMember]
        public PinValue PinState { get; set; } = PinValue.Low;

        [IgnoreDataMember]
        public int StateValue => PinState == PinValue.High ? 1 : 0;

        [IgnoreDataMember]
        public string Name
        {
            get
            {
                switch (PinType)
                {
                    case PinType.PoolPump:
                        return "Pool Pump";
                    case PinType.BoosterPump:
                        return "Booster Pump";
                    case PinType.Heater:
                        return "Heater";
                    case PinType.PoolLight:
                        return "Pool Light";
                    case PinType.SpaLight:
                        return "Spa Light";
                    case PinType.GroundLights:
                        return "Ground Lights";
                    case PinType.SpaPump :
                        return "Spa Pump";
                    default:
                        return "Unknown";
                }
            }
        }

    }
}
