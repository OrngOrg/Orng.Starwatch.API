// See LICENSE.txt - Starwatch

namespace Orng.Starwatch.API.Objects;

public class Player
{
    public int? Connection { get; set; }
    public string? Username { get; set; }
    public string? Nickname { get; set; }
    public string? AccountName { get; set; }
    public string? UUID { get; set; }
    public string? IP { get; set; }
    public bool? IsAnonymous => string.IsNullOrWhiteSpace(AccountName) || AccountName.Equals("<anonymous>");
    public bool? IsAdmin { get; set; }
    public bool? IsVPN { get; set; }
    // to-do: add World Location {get; set;}
}
