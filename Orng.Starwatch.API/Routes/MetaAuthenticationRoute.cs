namespace Orng.Starwatch.API;

public partial class ApiClient
{
    public static class MetaAuthenticationRoute
    {
        public const string RoutePath = "api/meta/authentication";
    }

    public ConversionResult<RestResponse<string[]?>> GetStarwatchSessions ()
    =>  GetRestResponseSync<RestResponse<string[]?>> (MetaAuthenticationRoute.RoutePath);

    public ConversionResult<EmptyRestResponse> ClearStarwatchSessions ()
    =>  DelRestResponseSync<EmptyRestResponse> (MetaAuthenticationRoute.RoutePath);
}
