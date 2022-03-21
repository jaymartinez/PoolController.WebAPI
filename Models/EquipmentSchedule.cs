using System.Runtime.Serialization;

namespace PoolController.WebAPI.Models
{
    public class EquipmentSchedule
    {
        public static readonly TimeSpan DefaultPoolStart = new (8, 30, 0); 
        public static readonly TimeSpan DefaultPoolEnd = new (14, 30, 0); 
        public static readonly TimeSpan DefaultBoosterStart = new (8, 35, 0); 
        public static readonly TimeSpan DefaultBoosterEnd = new (11, 35, 0); 
        public static readonly TimeSpan DefaultPoolLightStart = new (18, 00, 0); 
        public static readonly TimeSpan DefaultPoolLightEnd = new (21, 00, 0); 
        public static readonly TimeSpan DefaultSpaLightStart = new (18, 00, 0); 
        public static readonly TimeSpan DefaultSpaLightEnd = new (21, 00, 0);

        [DataMember]
        public ScheduleType Type { get; set; }

        [DataMember]
        public TimeSpan StartTime { get; set; }

        [DataMember]
        public TimeSpan EndTime { get; set; }

        [DataMember]
        public bool IsActive { get; set; } = false;
    }
}
