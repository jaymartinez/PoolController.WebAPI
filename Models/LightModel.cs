using System.Runtime.Serialization;

namespace PoolController.WebAPI.Models
{
    [Serializable]
    public class LightModel
    {
        [DataMember]
        public LightModeType CurrentMode { get; set; }

        [DataMember]
        public LightType LightType { get; set; }

        [DataMember]
        public LightModeType? PreviousMode { get; set; }
    }
}
