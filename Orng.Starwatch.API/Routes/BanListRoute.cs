using Orng.Starwatch.API.Objects;

namespace Orng.Starwatch.API;

public partial class ApiClient
{
    public static class BanListRoute
    {
        public const string RoutePath = "api/ban/list";

        public static string GetRoutePath(int page = 0, int limit = 10)
        => $"{RoutePath}?page={page}&limit={limit}";
    }

    public ConversionResult<RestResponse<List<Ban>?>> GetBans (int page = 0, int limit = 10)
    => GetRest<RestResponse<List<Ban>?>> (BanListRoute.GetRoutePath(page, limit));
}
