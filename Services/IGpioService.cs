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
    /// <param name="lightType">Indicates whether to save the pool or spa light mode</param>
    /// <returns><see cref="LightModel"/> object with updated <see cref="LightModel.CurrentMode"/> and <see cref="LightModel.PreviousMode"/></returns>
    LightModel SaveLightMode(LightType lightType);
}