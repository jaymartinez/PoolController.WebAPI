using PoolController.WebAPI.Models;

namespace PoolController.WebAPI.Services
{
    public interface IAppRepository
    {
        public EquipmentSchedule PoolPumpSchedule { get; set; }
        public EquipmentSchedule BoosterPumpSchedule { get; set; }
        public EquipmentSchedule PoolLightSchedule { get; set; }
        public EquipmentSchedule SpaLightSchedule { get; set; }
        public LightModeType PoolLightMode { get; set; }
        public LightModeType SpaLightMode { get; set; }
        public LightModeType PreviousPoolLightMode { get; set; }
        public LightModeType PreviousSpaLightMode { get; set; }

        public PiPin PoolPump { get; }
        public PiPin SpaPump { get; }
        public PiPin BoosterPump { get; }
        public PiPin PoolLight { get; }
        public PiPin SpaLight { get; }
        public PiPin GroundLights { get; }
        public PiPin Heater { get; }
        public IEnumerable<PiPin> AllPins { get; }

        void StartTimer();
    }
}
