namespace PoolController.WebAPI.Models
{
    /// <summary>
    /// The type of light, pool, spa, etc.
    /// <code><list type="bullet">
    /// <item><see cref="Pool"/>: 1</item>
    /// <item><see cref="Spa"/>: 2</item>
    /// <item><see cref="Ground"/>: 3</item>
    /// </list></code>
    /// </summary>
    public enum LightType : byte
    {
        Pool = 1,
        Spa = 2,
        Ground = 3
    }
}
