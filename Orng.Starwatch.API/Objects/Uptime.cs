// See License.txt - Starwatch

namespace Orng.Starwatch.API.Objects;

public class Uptime
{
    public long? Id { get; set; }
    public DateTime Started { get; set; }
    public DateTime? Ended { get; set; }
    public string? LastLog { get; set; }
    public string? Reason { get; set; }
}
