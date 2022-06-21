namespace Orng.Starwatch.API;

public partial class ApiClient
{
    public static class WorldRoute
    {
        public const string RoutePath = "api/world";
    }

    public ConversionResult<RestResponse<string[]>> GetActiveWorlds()
    =>  GetRestResponseSync<RestResponse<string[]>> (WorldRoute.RoutePath);
}
