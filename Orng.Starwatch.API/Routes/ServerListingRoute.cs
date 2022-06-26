using Orng.Starwatch.API.Objects;

namespace Orng.Starwatch.API;

public partial class ApiClient
{
    public static class ServerListingRoute
    {
        public const string RoutePath = "api/server/statistics/listing";
    }

    public ConversionResult<RestResponse<CompoundStatistic>> GetServerListing()
    => GetRest<RestResponse<CompoundStatistic>>(ServerListingRoute.RoutePath);
}
