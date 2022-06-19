using Newtonsoft.Json;

namespace Orng.Starwatch.API.Objects;

public class WorldRestore
{
    [JsonProperty("World")]
    public string? WorldWhereami { get; set; }

    [JsonProperty("Mirror")]
    public string? MirrorWhereami { get; set; }
}
