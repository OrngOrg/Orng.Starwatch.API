// See LICENSE.txt - Starwatch

namespace Orng.Starwatch.API.Objects;

public class PlayerKickResponse
{
    public List<Player> Players { get; set; } = new List<Player>();
    public int SuccessfulKicks { get; set; } = 0;
    public int FailedKicks { get; set; } = 0;
}
