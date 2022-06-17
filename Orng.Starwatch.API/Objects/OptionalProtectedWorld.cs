// See LICENSE.txt - Starwatch

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Orng.Starwatch.API.Objects;
public class OptionalProtectedWorld
{
    public string? Name { get; set; }
    public string? Whereami { get; set; }
    public HashSet<string>? AccountList { get; set; }
    public bool? AllowAnonymous { get; set; }

    [JsonConverter(typeof(StringEnumConverter))]
    public WhitelistMode? Mode { get; set; }
}

public enum WhitelistMode
{
    Whitelist,
    Blacklist
}
