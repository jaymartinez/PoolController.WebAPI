using System.Runtime.Serialization;

namespace PoolController.WebAPI.Models
{
    [Serializable]
    public class ApiResult<T>
    {
        [DataMember]
        public List<string> Messages { get; set; } = new List<string>();


        [DataMember]
        public T Data { get; set; }
    }
}
