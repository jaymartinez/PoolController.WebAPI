using System.Runtime.Serialization;

namespace PoolController.WebAPI.Models
{
    public class EquipmentSchedule
    {
        [DataMember]
        public ScheduleType Type { get; set; }

        [DataMember]
        public bool IsActive { get; set; } = false;

        [DataMember]
        public int StartHour { get; set; } = 8;

        [DataMember]
        public int StartMinute { get; set; } = 30;

        [DataMember]
        public int EndHour { get; set; } = 14;

        [DataMember]
        public int EndMinute { get; set; } = 30;

    }
}
