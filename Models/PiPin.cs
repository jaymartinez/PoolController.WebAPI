using System.Device.Gpio;
using System.Runtime.Serialization;

namespace PoolController.WebAPI.Models
{
    [Serializable]
    public class PiPin
    {
        [DataMember]
        public PinType PinType { get; set; }

        [DataMember]
        public DateTime? DateActivated { get; set; }

        [DataMember]
        public DateTime? DateDeactivated { get; set; }

        [DataMember]
        public PinValue PinState { get; set; }

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
