using Orng.Starwatch.API.Objects;

namespace Orng.Starwatch.API;

public partial class ApiClient
{
    public static class ServerStatisticsRoute
    {
        public const string RoutePath = "api/server/statistics";
    }

    public ConversionResult<RestResponse<Statistics?>> GetServerStatistics()
    =>  GetRestResponseSync<RestResponse<Statistics?>> (ServerStatisticsRoute.RoutePath);
}
