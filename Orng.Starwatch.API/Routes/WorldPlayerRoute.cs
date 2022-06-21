namespace Orng.Starwatch.API;

public partial class ApiClient
{
    public static class WorldPlayerRoute
    {
        public const string RoutePath = "api/world/:identifier/players";

        public static string GetRoutePath(string identifier)
        => RoutePath.Replace(":identifier", identifier);
    }

    public ConversionResult<RestResponse<Dictionary<int, string>?>> GetWorldPlayers (string identifier)
    =>  GetRestResponseSync<RestResponse<Dictionary<int, string>?>> (WorldPlayerRoute.GetRoutePath(identifier));
}
