using PoolController.WebAPI.Models;

namespace PoolController.WebAPI.Services
{
    public interface IAppRepository
    {
        public PoolModel Pool { get; }
        public SpaModel Spa { get; }
        public BoosterPumpModel Booster { get; }
        public LightModel GroundLights { get; }
        public HeaterModel Heater { get; }
        public IEnumerable<PiPin> AllModels { get; }
    }
}
