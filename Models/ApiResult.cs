using System.Runtime.Serialization;

namespace PoolController.WebAPI.Models
{
    [Serializable]
    public class ApiResult<T> 
        where T : class
    {
        public ApiResult() { }

        public ApiResult(T data, List<string>? messages = null)
        {
            Data = data;
            Messages = messages ?? new List<string>();
        }

        [DataMember]
        public List<string> Messages { get; set; } = new List<string>();


        [DataMember]
        public T? Data { get; set; } = null;
    }
}
