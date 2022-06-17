// See LICENSE.txt - Starwatch

namespace Orng.Starwatch.API.Objects;

public class GatewayConnection
{
    /// <summary>
    /// The unique ID of the connection
    /// </summary>
    public long? ConnectionID { get; set; }

    /// <summary>
    /// Text representation of the connection. Will use the Authentication name if available, otherwise the user's endpoint.
    /// </summary>
    public string? Identifier { get; set; }

    /// <summary>
    /// Has the connection terminated?
    /// </summary>
    public bool? HasTerminated { get; set; }
}
