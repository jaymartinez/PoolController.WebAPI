using System.Runtime.Serialization;

namespace PoolController.WebAPI.Models
{
    [Serializable]
    public class EquipmentSchedule : ISaveable<EquipmentSchedule>
    {
        public EquipmentSchedule(TimeSpan startTime, TimeSpan endTime, bool isActive = false)
        {
            StartTime = startTime;
            EndTime = endTime;
            IsActive = isActive;
        }

        [IgnoreDataMember]
        public static readonly TimeSpan DefaultPoolStart = new (8, 30, 0); 
        [IgnoreDataMember]
        public static readonly TimeSpan DefaultPoolEnd = new (14, 30, 0); 
        [IgnoreDataMember]
        public static readonly TimeSpan DefaultBoosterStart = new (8, 35, 0); 
        [IgnoreDataMember]
        public static readonly TimeSpan DefaultBoosterEnd = new (11, 35, 0); 
        [IgnoreDataMember]
        public static readonly TimeSpan DefaultPoolLightStart = new (18, 00, 0); 
        [IgnoreDataMember]
        public static readonly TimeSpan DefaultPoolLightEnd = new (21, 00, 0); 
        [IgnoreDataMember]
        public static readonly TimeSpan DefaultSpaLightStart = new (18, 00, 0); 
        [IgnoreDataMember]
        public static readonly TimeSpan DefaultSpaLightEnd = new (21, 00, 0);

        [DataMember]
        public TimeSpan StartTime { get; private set; }

        [DataMember]
        public TimeSpan EndTime { get; private set; }

        [DataMember]
        public bool IsActive { get; private set; } = false;

        public void Save(EquipmentSchedule model, bool saveChildData = false)
        {
            this.StartTime = model.StartTime;
            this.EndTime = model.EndTime;
            this.IsActive = model.IsActive;
        }
    }
}
