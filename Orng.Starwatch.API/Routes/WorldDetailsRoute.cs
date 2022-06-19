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

    public static class WorldDetailsRoute
    {
        public const string RoutePath = "/api/world/:identifier";

        public static string GetRoutePath (string identifier)
        => RoutePath.Replace(":identifier", identifier);
    }

    public ConversionResult<RestResponse<CelestialWorld?>> GetWorldDetails (string identifier)
    =>  GetRestResponseSync<RestResponse<CelestialWorld?>> (WorldDetailsRoute.GetRoutePath(identifier));

    public ConversionResult<RestResponse<bool?>> DeleteWorldMetadata (string identifier)
    =>  DelRestResponseSync<RestResponse<bool?>> (WorldDetailsRoute.GetRoutePath(identifier));
}
