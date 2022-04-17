using System.Runtime.Serialization;

namespace PoolController.WebAPI.Models
{
    [Serializable]
    public class GroundLightsModel : LightModel
    {
        public GroundLightsModel()
            :base(new EquipmentSchedule(
               EquipmentSchedule.DefaultSpaLightStart,
               EquipmentSchedule.DefaultSpaLightEnd), Pins.GroundLights, PinType.GroundLights)
        { }
    }
}
