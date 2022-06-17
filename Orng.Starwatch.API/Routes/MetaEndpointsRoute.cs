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

    public static class MetaEndpointsRoute
    {
        public const string RoutePath = "api/meta/endpoints";
    }

    public ConversionResult<RestResponse<string[]?>> GetEndpoints ()
    =>  GetRestResponseSync<RestResponse<string[]?>>(MetaEndpointsRoute.RoutePath);
}
