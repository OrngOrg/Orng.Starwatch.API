using Orng.Starwatch.API.Objects;

namespace Orng.Starwatch.API;

public partial class ApiClient
{
    public static class MetaAuthenticationDetailsRoute
    {
        public const string RoutePath = "api/meta/authentication/{0}";

        public static string GetRoutePath (string accountName = "@me")
        => string.Format(RoutePath, accountName);
    }

    public ConversionResult<RestResponse<MetaAuthenticationDetailsResponse?>> GetStarwatchSessionDetails (string accountName = "@me")
    => GetRest<RestResponse<MetaAuthenticationDetailsResponse?>> (MetaAuthenticationDetailsRoute.GetRoutePath(accountName));
}
