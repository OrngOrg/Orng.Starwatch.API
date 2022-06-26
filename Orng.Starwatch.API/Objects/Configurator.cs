// See LICENSE.txt - Starwatch

namespace Orng.Starwatch.API.Objects;
public class Configurator
{
    /// <summary>
    /// The name of the server
    /// </summary>
    public string? ServerName { get; set; }

    /// <summary>
    /// Allow anonymous connections onto the server
    /// </summary>
    public bool? AllowAnonymousConnections { get; set; }

    /// <summary>
    /// Allow assets mismatch
    /// </summary>
    public bool? AllowAssetsMismatch { get; set; }

    /// <summary>
    /// The max players allowed
    /// </summary>
    public int? MaxPlayers { get; set; }

    /// <summary> Address binding for the server </summary>
    public string? GameServerBind { get; set; }

    /// <summary> Port for the server </summary>
    public int? GameServerPort { get; set; }

    /// <summary> Address binding for the query </summary>
    public string? QueryServerBind { get; set; }

    /// <summary> Port for the query </summary>
    public int? QueryServerPort { get; set; }
}
