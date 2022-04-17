using System.Runtime.Serialization;

namespace PoolController.WebAPI.Models
{
    [Serializable]
    public class SpaModel : PiPin, ISaveable<SpaModel>
    {
        [DataMember]
        public SpaLightModel Light { get; }

        public SpaModel()
            :base(Pins.SpaPump_1, PinType.SpaPump, Pins.SpaPump_2)
        {
            Light = new SpaLightModel();
        }

        public void Save(SpaModel model, bool saveChildData = false)
        {
            DateActivated = model.DateActivated;
            DateDeactivated = model.DateDeactivated;
            PinValue = model.PinValue;

            if (saveChildData)
            {
                Light.Save(model.Light);
            }
        }
    }
}
