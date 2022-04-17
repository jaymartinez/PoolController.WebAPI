using System.Runtime.Serialization;

namespace PoolController.WebAPI.Models
{
    [Serializable]
    public class LightModel : PiPin, ISaveable<LightModel>
    {
        public LightModel(EquipmentSchedule schedule, int gpioPin, PinType type)
            :base(gpioPin, type)
        {
            Schedule = schedule;
        }

        [DataMember]
        public EquipmentSchedule Schedule { get; private set; }

        [DataMember]
        public LightModeType CurrentMode { get; set; }

        [DataMember]
        public LightModeType? PreviousMode { get; set; }

        public void Save(LightModel model, bool saveChildData = false)
        {
            CurrentMode = model.CurrentMode;
            PreviousMode = model.PreviousMode;

            if (saveChildData)
            {
                Schedule.Save(model.Schedule);
            }
        }
    }
}
