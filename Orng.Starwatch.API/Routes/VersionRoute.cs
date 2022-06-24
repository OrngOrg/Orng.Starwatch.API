namespace Orng.Starwatch.API;

public partial class ApiClient
{
    public static class VersionRoute
    {
        public const string RoutePath = "api/version";
    }

    public ConversionResult<RestResponse<string?>> GetStarwatchVersion ()
    =>  GetRestResponseSync<RestResponse<string?>> (VersionRoute.RoutePath);
}
