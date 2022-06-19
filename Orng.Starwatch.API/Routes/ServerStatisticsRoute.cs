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

    public static class ServerStatisticsRoute
    {
        public const string RoutePath = "api/server/statistics";
    }

    public ConversionResult<RestResponse<Statistics>> GetStatistics()
    =>  GetRestResponseSync<RestResponse<Statistics>> (ServerStatisticsRoute.RoutePath);
}
