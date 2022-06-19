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

    public static class WorldRoute
    {
        public const string RoutePath = "api/world";
    }

    public ConversionResult<RestResponse<string[]>> GetActiveWorlds()
    =>  GetRestResponseSync<RestResponse<string[]>> (WorldRoute.RoutePath);
}
