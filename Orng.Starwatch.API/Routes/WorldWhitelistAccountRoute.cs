using Orng.Starwatch.API.Objects;

namespace Orng.Starwatch.API;

public partial class ApiClient
{
    public static class WorldWhitelistAccountRoute
    {
        public const string RoutePath = "api/world/:identifier/protection/:account";

        public static string GetRoutePath (string identifier, string account)
        => RoutePath.Replace(":identifier", identifier).Replace(":account", account);
    }

    public ConversionResult<RestResponse<ListedAccount?>> CheckAccountWhitelistOnWorld (string identifier, string account)
    => GetRest<RestResponse<ListedAccount?>> (WorldWhitelistAccountRoute.GetRoutePath(identifier, account));

    public ConversionResult<RestResponse<bool?>> RemoveAccountWhitelistOnWorld (string identifier, string account)
    => DelRest<RestResponse<bool?>> (WorldWhitelistAccountRoute.GetRoutePath(identifier, account));

    public ConversionResult<RestResponse<ListedAccount?>> AddAccountWhitelistOnWorld (string identifier, string account)
    => PostRest<RestResponse<ListedAccount?>> (WorldWhitelistAccountRoute.GetRoutePath(identifier, account));
}
