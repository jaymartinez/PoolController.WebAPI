namespace PoolController.WebAPI.Models
{
    /// <summary>
    /// Used for any of the light theme button taps, passes the number of times to toggle the light switch.
    /// <code><list type="bullet">
    /// <item><see cref="Sam"/>: 1</item>
    /// <item><see cref="Party"/>: 2</item>
    /// <item><see cref="Romance"/>: 3</item>
    /// <item><see cref="Caribbean"/>: 4</item>
    /// <item><see cref="American"/>: 5</item>
    /// <item><see cref="CaliforniaSunset"/>: 6</item>
    /// <item><see cref="Royal"/>: 7</item>
    /// <item><see cref="Blue"/>: 8</item>
    /// <item><see cref="Green"/>: 9</item>
    /// <item><see cref="Red"/>: 10</item>
    /// <item><see cref="White"/>: 11</item>
    /// <item><see cref="Magenta"/>: 12</item>
    /// <item><see cref="Hold"/>: 13</item>
    /// <item><see cref="Recall"/>: 14</item>
    /// </list></code>
    /// </summary>
    public enum LightModeType : byte
    {
        NotSet = 0,
        Sam = 1,
        Party = 2,
        Romance = 3,
        Caribbean = 4,
        American = 5,
        CaliforniaSunset = 6,
        Royal = 7,
        Blue = 8,
        Green = 9,
        Red = 10,
        White = 11,
        Magenta = 12,
        Hold = 13,
        Recall = 14
    }
}
