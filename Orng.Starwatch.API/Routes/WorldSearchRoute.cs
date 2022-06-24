using Orng.Starwatch.API.Objects;

namespace Orng.Starwatch.API;

public partial class ApiClient
{
    public static class WorldSearchRoute
    {
        public const string RoutePath = "api/world/search";

        public static string GetRoutePath(long? xmin = null, long? xmax = null, long? ymin = null, long? ymax = null)
        {
            string query = "";
            var queryValues = new Dictionary<string, long?>();

            if (xmin is not null)
                queryValues.Add("xmin", xmin);

            if (xmax is not null)
                queryValues.Add("xmax", xmax);

            if (ymin is not null)
                queryValues.Add("ymin", ymin);

            if (ymax is not null)
                queryValues.Add("ymax", ymax);

            if (queryValues.Count == 0)
                return RoutePath;

            var keys = queryValues.Keys.ToList();
            for (int i = 0; i < keys.Count; i++)
            {
                query += keys[i] + "=" + queryValues[keys[i]];

                if (i < keys.Count - 1)
                    query += "&";
            }

            return $"{RoutePath}?{query}";
        }
    }

    public ConversionResult<RestResponse<List<CelestialWorld>?>> GetWorld (long? xmin = null, long? xmax = null, long? ymin = null, long? ymax = null)
    =>  GetRestResponseSync<RestResponse<List<CelestialWorld>?>> (WorldSearchRoute.GetRoutePath(xmin, xmax, ymin, ymax));
}
