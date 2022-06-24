using Orng.Starwatch.API.Objects;

namespace Orng.Starwatch.API;

public partial class ApiClient
{
    public static class MetaGatewayRoute
    {
        public const string RoutePath = "api/meta/gateway";
    }

    public ConversionResult<RestResponse<GatewayListing?>> GetGateways()
    =>  GetRestResponseSync<RestResponse<GatewayListing?>> (MetaGatewayRoute.RoutePath);
}
