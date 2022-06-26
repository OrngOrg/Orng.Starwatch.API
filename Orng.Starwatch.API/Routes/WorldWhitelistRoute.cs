using Orng.Starwatch.API.Objects;
using Newtonsoft.Json;

namespace Orng.Starwatch.API;

public partial class ApiClient
{
    public static class WorldWhitelistRoute
    {
        public const string RoutePath = "api/world/:identifier/protection";

        public static string GetRoutePath (string identifier)
        => RoutePath.Replace(":identifier", identifier);
    }

    public ConversionResult<RestResponse<OptionalProtectedWorld?>> GetWorldWhitelist (string identifier)
    =>  GetRest<RestResponse<OptionalProtectedWorld?>> (WorldWhitelistRoute.GetRoutePath(identifier));

    public ConversionResult<RestResponse<bool?>> DeleteWorldWhitelist (string identifier)
    =>  DelRest<RestResponse<bool?>> (WorldWhitelistRoute.GetRoutePath(identifier));

    public ConversionResult<RestResponse<OptionalProtectedWorld?>> AddWorldWhitelist (string identifier, OptionalProtectedWorld whitelist)
    => PostRest<RestResponse<OptionalProtectedWorld?>> (WorldWhitelistRoute.GetRoutePath(identifier), whitelist);
}
