// See LICENSE.txt - Starwatch

namespace Orng.Starwatch.API.Objects;

public struct GatewayListing
{
    public int ActiveSessions { get; set; }
    public int InactiveSessions { get; set; }
    public GatewayConnection[] Connections { get; set; }
}
