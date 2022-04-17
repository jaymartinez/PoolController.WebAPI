using PoolController.WebAPI.Models;
using System.Device.Gpio;

public interface IGpioService
{
    /// <summary>
    /// Gets the statuses for all the equipment
    /// </summary>
    /// <returns>List of PiPin objects with the status populated</returns>
    IEnumerable<PiPin> GetAllStatuses();

    PinValue Read(int pinNumber);

    bool Toggle(PinType pinType);

    /// <summary>
    /// Saves the pool light mode
    /// </summary>
    /// <param name="lightMode">The light mode to save</param>
    /// <returns><see cref="LightModel"/> object with updated <see cref="LightModel.CurrentMode"/> and <see cref="LightModel.PreviousMode"/></returns>
    LightModel SavePoolLightMode(LightModeType lightMode);

    /// <summary>
    /// Saves the spa light mode
    /// </summary>
    /// <param name="lightMode">The light mode to save</param>
    /// <returns><see cref="LightModel"/> object with updated <see cref="LightModel.CurrentMode"/> and <see cref="LightModel.PreviousMode"/></returns>
    LightModel SaveSpaLightMode(LightModeType lightMode);

    /// <summary>
    /// Gets the current PoolModel object stored in the AppRepository
    /// </summary>
    /// <returns>The current <see cref="PoolModel"/></returns>
    PoolModel GetPool();

    /// <summary>
    /// Gets the current SpaModel object stored in the AppRepository
    /// </summary>
    /// <returns>The current <see cref="SpaModel"/></returns>
    SpaModel GetSpa();

    /// <summary>
    /// Gets the current BoosterPumpModel object stored in the AppRepository
    /// </summary>
    /// <returns>The current <see cref="BoosterPumpModel"/></returns>
    BoosterPumpModel GetBooster();

    /// <summary>
    /// Gets the current GroundLightsModel object stored in the AppRepository
    /// </summary>
    /// <returns>The current <see cref="LightModel"/></returns>
    LightModel GetGroundLights();

    /// <summary>
    /// Gets the current HeaterModel object stored in the AppRepository
    /// </summary>
    /// <returns>The current <see cref="HeaterModel"/></returns>
    HeaterModel GetHeater();

    /// <summary>
    /// Saves the PoolModel to the AppRepository
    /// </summary>
    /// <returns>The current <see cref="PoolModel"/></returns>
    PoolModel SavePool(PoolModel poolModel);

    /// <summary>
    /// Saves the SpaModel to the AppRepository
    /// </summary>
    /// <returns>The current <see cref="SpaModel"/></returns>
    SpaModel SaveSpa(SpaModel spaModel);

    /// <summary>
    /// Saves the BoosterPumpModel to the AppRepository
    /// </summary>
    /// <returns>The current <see cref="BoosterPumpModel"/></returns>
    BoosterPumpModel SaveBooster(BoosterPumpModel boosterPumpModel);

    /// <summary>
    /// Saves the GroundLightsModel to the AppRepository
    /// </summary>
    /// <returns>The current <see cref="LightModel"/></returns>
    LightModel SaveGroundLights(LightModel groundLightsModel);

    /// <summary>
    /// Saves the HeaterModel to the AppRepository
    /// </summary>
    /// <returns>The current <see cref="HeaterModel"/></returns>
    HeaterModel SaveHeater(HeaterModel heaterModel);
}