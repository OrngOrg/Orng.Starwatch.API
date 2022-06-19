// See LICENSE.txt - Starwatch

namespace Orng.Starwatch.API.Objects;
public class ListedAccount
{
    public long? ProtectionId { get; set; }
    public string? AccountName { get; set; }
    public string? Reason { get; set; } = string.Empty;
}
