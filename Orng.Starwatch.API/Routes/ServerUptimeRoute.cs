using Orng.Starwatch.API.Objects;

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

    public static class ServerUptimeRoute
    {
        public const string RoutePath = "api/server/uptime";
    }

    public ConversionResult<RestResponse<List<Uptime>>> GetServerUptime()
    =>  GetRestResponseSync<RestResponse<List<Uptime>>> (ServerUptimeRoute.RoutePath);
}
