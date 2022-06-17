namespace Orng.Starwatch.API;

public partial class ApiClient
{
    public static class MetaAuthenticationRoute
    {
        public const string RoutePath = "api/meta/authentication";
    }

    public ConversionResult<RestResponse<string[]?>> GetAuthentications ()
    =>  GetRestResponseSync<RestResponse<string[]?>> (MetaAuthenticationRoute.RoutePath);

    public ConversionResult<RestResponse<object?>> DelAuthentications ()
    =>  DelRestResponseSync<RestResponse<object?>> (MetaAuthenticationRoute.RoutePath);
}
