using System.Runtime.Serialization;

namespace PoolController.WebAPI.Models
{
    [Serializable]
    public class PoolModel: PiPin, ISaveable<PoolModel>
    {
        [DataMember]
        public EquipmentSchedule Schedule { get; }

        [DataMember]
        public PoolLightModel Light { get; }

        public PoolModel()
            :base(Pins.PoolPump_1, PinType.PoolPump, Pins.PoolPump_2)
        {
            Light = new PoolLightModel();

            Schedule = new EquipmentSchedule(
                EquipmentSchedule.DefaultPoolStart, 
                EquipmentSchedule.DefaultPoolEnd);
        }

        public void Save(PoolModel model, bool saveChildData = false)
        {
            if (model == null) return;

            PinValue = model.PinValue;
            DateActivated = model.DateActivated;
            DateDeactivated = model.DateDeactivated;

            if (saveChildData)
            {
                Schedule.Save(model.Schedule);
                Light.Save(model.Light);
            }
        }
    }
}
