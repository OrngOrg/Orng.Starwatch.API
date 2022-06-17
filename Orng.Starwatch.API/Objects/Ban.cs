// See LICENSE.txt - Starwatch
using Newtonsoft.Json;

namespace Orng.Starwatch.API.Objects;

public class Ban
{
    [JsonProperty("ticket", NullValueHandling = NullValueHandling.Ignore)]
    public long? Ticket { get; set; }

    [JsonProperty("ip", NullValueHandling = NullValueHandling.Ignore)]
    public string? IP { get; set; }

    [JsonProperty("uuid", NullValueHandling = NullValueHandling.Ignore)]
    public string? UUID { get; set; }

    [JsonProperty("reason", NullValueHandling = NullValueHandling.Ignore)]
    public string? Reason { get; set; }

    [JsonProperty("bannedBy", NullValueHandling = NullValueHandling.Ignore)]
    public string? Moderator { get; set; }

    [JsonProperty("bannedAt", NullValueHandling = NullValueHandling.Ignore)]
    public long? BannedAt { get; set; }

    [JsonProperty("expiresAt", NullValueHandling = NullValueHandling.Ignore)]
    public long? ExpiresAt { get; set; }
}
