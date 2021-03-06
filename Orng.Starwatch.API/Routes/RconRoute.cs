using Orng.Starwatch.API.Objects;
using Newtonsoft.Json;

namespace Orng.Starwatch.API;

public partial class ApiClient
{
    public static class RconRoute
    {
        public const string RoutePath = "api/rcon";
    }

    public class RconRoutePayload
    {
        public string? Command { get; set; }
    }

    public ConversionResult<RestResponse<RconResponse?>> SendRconCommand (string command)
    => PostRest<RestResponse<RconResponse?>> (RconRoute.RoutePath, new RconRoutePayload { Command = command });
}
