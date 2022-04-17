using System.Runtime.Serialization;

namespace PoolController.WebAPI.Models
{
    [Serializable]
    public class BoosterPumpModel : PiPin, ISaveable<BoosterPumpModel>
    {
        [DataMember]
        public EquipmentSchedule Schedule { get; }

        public BoosterPumpModel()
            :base(Pins.BoosterPump_1, PinType.BoosterPump, Pins.BoosterPump_2)
        {
            Schedule = new EquipmentSchedule(
                EquipmentSchedule.DefaultBoosterStart,
                EquipmentSchedule.DefaultBoosterEnd);
        }

        public void Save(BoosterPumpModel model, bool saveChildData = false)
        {
            DateActivated = model.DateActivated;
            DateDeactivated = model.DateDeactivated;
            PinValue = model.PinValue;

            if (saveChildData)
            {
                Schedule.Save(model.Schedule);
            }
        }
    }
}
