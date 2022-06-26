namespace Orng.Starwatch.API;

public partial class ApiClient
{
    public static class VersionRoute
    {
        public const string RoutePath = "api/version";
    }

    public ConversionResult<RestResponse<string?>> GetStarwatchVersion ()
    =>  GetRest<RestResponse<string?>> (VersionRoute.RoutePath);
}
