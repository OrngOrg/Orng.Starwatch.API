namespace Orng.Starwatch.API;

public partial class ApiClient
{
    public static class WorldRoute
    {
        public const string RoutePath = "api/world";
    }

    public ConversionResult<RestResponse<List<string>?>> GetActiveWorlds ()
    =>  GetRest<RestResponse<List<string>?>> (WorldRoute.RoutePath);
}
