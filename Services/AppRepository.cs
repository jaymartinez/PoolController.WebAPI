using PoolController.WebAPI.Models;

namespace PoolController.WebAPI.Services
{
    public class AppRepository : IAppRepository
    {
        public PoolModel Pool { get; } = new PoolModel();
        public SpaModel Spa { get; } = new SpaModel();
        public BoosterPumpModel Booster { get; } = new BoosterPumpModel();
        public LightModel GroundLights { get; } = new GroundLightsModel();
        public HeaterModel Heater { get; } = new HeaterModel();
        public IEnumerable<PiPin> AllModels { get; }

        public AppRepository(ILogger<AppRepository> logger)
        {
            AllModels = new List<PiPin>()
            {
                Pool,
                Spa,
                Booster,
                GroundLights,
                Heater
            };

            logger.LogInformation("AppRepository Created!!");
        }
    }
}
