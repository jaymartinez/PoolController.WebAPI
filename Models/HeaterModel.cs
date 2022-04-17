using System.Runtime.Serialization;

namespace PoolController.WebAPI.Models
{
    [Serializable]
    public class HeaterModel : PiPin, ISaveable<HeaterModel>
    {
        public HeaterModel()
            :base(Pins.Heater, PinType.Heater)
        { }

        public void Save(HeaterModel model, bool saveChildData = false)
        {
            DateActivated = model.DateActivated;
            DateDeactivated = model.DateDeactivated;
            PinValue = model.PinValue;
        }
    }
}
