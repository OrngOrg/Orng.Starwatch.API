using Orng.Starwatch.API.Objects;

namespace Orng.Starwatch.API;

public partial class ApiClient
{
    public static class MapSystemRoute
    {
        public const string RoutePath = "api/map/{0}";

        public static string GetRoutePath (string system)
        => string.Format(RoutePath, system);
    }

    public ConversionResult<RestResponse<List<CelestialWorld>?>> GetMapSystem (string system)
    =>  GetRest<RestResponse<List<CelestialWorld>?>> (MapSystemRoute.GetRoutePath(system));
}
