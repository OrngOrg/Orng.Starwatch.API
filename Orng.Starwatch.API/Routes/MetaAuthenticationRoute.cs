namespace Orng.Starwatch.API;

public partial class ApiClient
{
    public static class MetaAuthenticationRoute
    {
        public const string RoutePath = "api/meta/authentication";
    }

    public ConversionResult<RestResponse<string[]?>> GetStarwatchSessions ()
    => GetRest<RestResponse<string[]?>> (MetaAuthenticationRoute.RoutePath);

    public ConversionResult<EmptyRestResponse> ClearStarwatchSessions ()
    => DelRest<EmptyRestResponse> (MetaAuthenticationRoute.RoutePath);
}
