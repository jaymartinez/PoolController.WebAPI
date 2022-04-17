using System;

namespace PoolController.WebAPI.Models
{
    /// <summary>
    /// Identifies the type of schedule
    /// <code><list type="bullet">
    /// <item><see cref="Booster"/>: 1</item>
    /// <item><see cref="Pool"/>: 2</item>
    /// <item><see cref="PoolLight"/>: 3</item>
    /// <item><see cref="SpaLight"/>: 4</item>
    /// <item><see cref="GroundLights"/>: 5</item>
    /// </list></code>
    /// </summary>
    public enum ScheduleType : byte
    {
        Booster = 1,
        Pool = 2,
        PoolLight = 3,
        SpaLight = 4,
        GroundLights = 5,
    }
}
