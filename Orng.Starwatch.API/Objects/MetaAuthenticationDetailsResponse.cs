// See LICENSE.txt - Starwatch

namespace Orng.Starwatch.API.Objects;

public class MetaAuthenticationDetailsResponse
{
    public string? Name { get; set; } = string.Empty;

    public bool? IsBot { get; set; } = false;

    public bool? IsUser { get; set; } = false;

    public bool? IsAdmin { get; set; } = false;

    public AuthLevel? AuthType { get; set; } = AuthLevel.Anonymous;

    public DateTime? LastActionTime { get; set; } = DateTime.MinValue;

    public long? TotalActionsPerformed { get; set; } = 0;

    public string? LastAction { get; set; } = string.Empty;
}
