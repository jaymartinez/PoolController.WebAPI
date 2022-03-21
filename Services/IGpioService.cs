using PoolController.WebAPI.Models;
using System.Device.Gpio;

public interface IGpioService
{
    /// <summary>
    /// Writes the value to the pin and returns the final state of the pin
    /// </summary>
    /// <param name="pinNumber">Pin number to write to</param>
    /// <param name="valueToWrite">The value to write, high or low</param>
    /// <returns>The final pin value if the write was successful</returns>
    PinValue Write(int pinNumber, PinValue valueToWrite);

    /// <summary>
    /// Read the current value of a pin
    /// </summary>
    /// <param name="pinNumber">The pin to read the value of</param>
    /// <returns></returns>
    PinValue Read(int pinNumber);

    /// <summary>
    /// Toggle a device pin. If it's currently low it will toggle it high, etc.
    /// </summary>
    /// <param name="pinType">The <see cref="PinType"/> to toggle. If it's type Pool it will toggle both pins assigned to the pool because there
    /// are two legs of 110v powering the pool, same with the booster pump and spa.</param>
    /// <returns>An updated <see cref="PiPin"/> object with the current state after toggling it.</returns>
    PiPin Toggle(PinType pinType);

    /// <summary>
    /// Gets the statuses for all the equipment
    /// </summary>
    /// <returns>List of PiPin objects with the status populated</returns>
    IEnumerable<PiPin> GetAllStatuses();

    /// <summary>
    /// Save light mode for the pool or spa light.
    /// </summary>
    /// <param name="mode">The light mode to save</param>
    /// <param name="lightType">Either the pool or spa</param>
    /// <returns><see cref="LightModel"/> object with updated <see cref="LightModel.CurrentMode"/> and <see cref="LightModel.PreviousMode"/></returns>
    LightModel SaveLightMode(LightModeType mode, LightType lightType);

    //var result = await _api.Get<Response<LightServerModel>>($"getCurrentLightMode?lightType={lightType}");
    /// <summary>
    /// Gets the currently active light mode for the passed in light type
    /// </summary>
    /// <param name="lightType">The <see cref="LightType"/> to get the current mode for</param>
    /// <returns></returns>
    LightModel GetCurrentLightMode(LightType lightType);

    /// <summary>
    /// Gets the <see cref="EquipmentSchedule"/> for the passed in type
    /// </summary>
    /// <param name="scheduleType">The <see cref="ScheduleType"/> to get the schedule for</param>
    /// <returns>Fully populated schedule object</returns>
    EquipmentSchedule GetSchedule(ScheduleType scheduleType);

    /// <summary>
    /// Sets the s
    /// </summary>
    /// <param name="schedule"></param>
    /// <returns></returns>
    EquipmentSchedule SetSchedule(EquipmentSchedule schedule);

    //result = await _api.Get<Response<PiPin>>($"status?pinType={pinType}");

    /// <summary>
    /// Get the status for the passed in pin type
    /// </summary>
    /// <param name="pinType">The <see cref="PinType"/> to get the status for</param>
    /// <returns>A fully populated <see cref="PiPin"/> object</returns>
    PiPin GetEquipmentStatus(PinType pinType);
}