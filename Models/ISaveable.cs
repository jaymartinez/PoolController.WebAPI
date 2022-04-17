using System.Device.Gpio;

namespace PoolController.WebAPI.Models
{
    public interface ISaveable<T>
    {
        void Save(T model, bool saveChildData = false);
    }
}
