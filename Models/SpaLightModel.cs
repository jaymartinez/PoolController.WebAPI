using System.Runtime.Serialization;

namespace PoolController.WebAPI.Models
{
    public class SpaLightModel : LightModel
    {
        public SpaLightModel()
            :base (new EquipmentSchedule(
                EquipmentSchedule.DefaultSpaLightStart, 
                EquipmentSchedule.DefaultSpaLightEnd, true), 
                 Pins.SpaLight, 
                 PinType.SpaLight)
        { }
    }
}
