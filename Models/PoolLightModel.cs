using System.Runtime.Serialization;

namespace PoolController.WebAPI.Models
{
    public class PoolLightModel : LightModel
    {
        public PoolLightModel()
            :base(new EquipmentSchedule(
                EquipmentSchedule.DefaultPoolLightStart, 
                EquipmentSchedule.DefaultPoolLightEnd, true), Pins.PoolLight, PinType.PoolLight)
        { }
    }
}
