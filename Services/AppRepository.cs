using PoolController.WebAPI.Models;
using System.Device.Gpio;

namespace PoolController.WebAPI.Services
{

    public class AppRepository : IAppRepository
    {
        readonly Timer _timer;

        EquipmentSchedule IAppRepository.PoolPumpSchedule { get; set; } = new EquipmentSchedule()
        {
            StartTime = EquipmentSchedule.DefaultPoolStart,
            EndTime = EquipmentSchedule.DefaultPoolEnd,
            IsActive = false,
            Type = ScheduleType.Pool
        };

        EquipmentSchedule IAppRepository.BoosterPumpSchedule { get; set; } = new EquipmentSchedule()
        {
            StartTime = EquipmentSchedule.DefaultBoosterStart,
            EndTime = EquipmentSchedule.DefaultBoosterEnd,
            IsActive = false,
            Type= ScheduleType.Booster
        };

        EquipmentSchedule IAppRepository.PoolLightSchedule { get; set; } = new EquipmentSchedule()
        {
            StartTime = EquipmentSchedule.DefaultPoolLightStart,
            EndTime = EquipmentSchedule.DefaultPoolLightEnd,
            IsActive = true,
            Type = ScheduleType.PoolLight
        };

        EquipmentSchedule IAppRepository.SpaLightSchedule { get; set; } = new EquipmentSchedule()
        {
            StartTime = EquipmentSchedule.DefaultSpaLightStart,
            EndTime = EquipmentSchedule.DefaultSpaLightEnd,
            IsActive = true,
            Type = ScheduleType.SpaLight
        };

        LightModeType IAppRepository.SpaLightMode { get; set; } = LightModeType.Caribbean;
        LightModeType IAppRepository.PoolLightMode { get; set; } = LightModeType.Caribbean;
        LightModeType IAppRepository.PreviousSpaLightMode { get; set; } = LightModeType.NotSet;
        LightModeType IAppRepository.PreviousPoolLightMode { get; set; } = LightModeType.NotSet;

        public PiPin PoolPump { get; } = new PiPin(PinType.PoolPump);
        public PiPin SpaPump { get; } = new PiPin(PinType.SpaPump); 
        public PiPin BoosterPump { get; } = new PiPin(PinType.BoosterPump);
        public PiPin PoolLight { get; } = new PiPin(PinType.PoolLight);
        public PiPin SpaLight { get; } = new PiPin(PinType.SpaLight);
        public PiPin GroundLights { get; } = new PiPin(PinType.GroundLights);
        public PiPin Heater { get; } = new PiPin(PinType.Heater);
        public IEnumerable<PiPin> AllPins { get; }

        public AppRepository()
        {
            AllPins = new List<PiPin>()
            {
                PoolPump,
                SpaPump,
                BoosterPump,
                PoolLight,
                SpaLight,
                GroundLights,
                Heater
            };
        }

        public void StartTimer()
        {
            return;
        }
    }
}
