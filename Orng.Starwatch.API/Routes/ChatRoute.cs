using Orng.Starwatch.API.Objects;
using Newtonsoft.Json;

namespace Orng.Starwatch.API;

public partial class ApiClient
{
    public static class ChatRoute
    {
        public const string RoutePath = "api/chat";

        public static string GetRoutePath (bool includeTag = false)
        => $"{RoutePath}?include_tag={includeTag}";
    }

    public class ChatRoutePayload
    {
        public string? Content { get; set; }

        public ChatRoutePayload(string content) => Content = content;
    }

    public ConversionResult<RestResponse<RconResponse?>> PostChat (string content, bool includeTag = false)
    => PostRestResponseSync<RestResponse<RconResponse?>> (ChatRoute.GetRoutePath(includeTag), JsonConvert.SerializeObject(new ChatRoutePayload(content)));
}
