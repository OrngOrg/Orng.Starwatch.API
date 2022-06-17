// See LICENSE.txt - Starwatch

namespace Orng.Starwatch.API.Objects;

public class CelestialWorld
{
    /// <summary>
    /// Universe X coordinate of the planet
    /// </summary>
    public long? X { get; set; }

    /// <summary>
    /// Universe Y coordinate of the planet
    /// </summary>
    public long? Y { get; set; }

    /// <summary>
    /// Universe Z coordinate of the planet
    /// </summary>
    public long? Z { get; set; }

    /// <summary>
    /// The planet ID of the world
    /// </summary>
    public int? Planet { get; set; }

    /// <summary>
    /// The moon ID of the world. Only set if the world is a moon.
    /// </summary>
    public int? Moon { get; set; }
}
