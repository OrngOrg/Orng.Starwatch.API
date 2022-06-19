using Orng.Starwatch.API.Objects;
using Newtonsoft.Json;

namespace Orng.Starwatch.API;

public partial class ApiClient
{
    /*
    public static class VersionRoute
    {
        public const string RouteBase = "api/version";
    }

    public ConversionResult<RestResponse<string>> GetVersion()
    => GetRestResponseSync<RestResponse<string>>(VersionRoute.RouteBase);*/

    public static class RconRoute
    {
        public const string RoutePath = "api/rcon";
    }

    public class RconRoutePayload
    {
        public string? Command { get; set; }
    }

    public ConversionResult<RestResponse<RconResponse>> PostRcon(string command)
    => PostRestResponseSync<RestResponse<RconResponse>> (RconRoute.RoutePath, JsonConvert.SerializeObject(new RconRoutePayload { Command = command }));
}
