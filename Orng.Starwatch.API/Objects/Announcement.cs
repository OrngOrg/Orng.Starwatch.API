// See LICENSE.txt - Starwatch

namespace Orng.Starwatch.API.Objects;

public class Announcement
{
    public int? Id { get; set; } = null;
    public string? Message { get; set; } = null;
    public double? Interval { get; set; } = null;
    public bool? Enabled { get; set; } = null;
}

