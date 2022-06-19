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

    public static class WorldWhitelistRoute
    {
        public const string RoutePath = "api/world/:identifier/protection";

        public static string GetRoutePath (string identifier)
        => RoutePath.Replace(":identifier", identifier);
    }

    public ConversionResult<RestResponse<OptionalProtectedWorld?>> GetWorldWhitelist (string identifier)
    =>  GetRestResponseSync<RestResponse<OptionalProtectedWorld?>> (WorldWhitelistRoute.GetRoutePath(identifier));

    public ConversionResult<RestResponse<bool?>> DeleteWorldWhitelist (string identifier)
    =>  DelRestResponseSync<RestResponse<bool?>> (WorldWhitelistRoute.GetRoutePath(identifier));

    public ConversionResult<RestResponse<OptionalProtectedWorld?>> AddWorldWhitelist (string identifier, OptionalProtectedWorld whitelist)
    => PostRestResponseSync<RestResponse<OptionalProtectedWorld?>> (WorldWhitelistRoute.GetRoutePath(identifier), JsonConvert.SerializeObject(whitelist));
}
