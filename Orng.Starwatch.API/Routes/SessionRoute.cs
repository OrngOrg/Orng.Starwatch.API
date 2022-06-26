namespace Orng.Starwatch.API;

public partial class ApiClient
{
    public static class SessionRoute
    {
        public const string RoutePath = "api/session";

        public static string GetRoutePath (string? connection, string? username, string? account, string? ip, string? uuid)
        {
            var queryValues = new Dictionary<string, string>();

            if (uuid is not null)
                queryValues.Add("uuid", uuid);

            if (ip is not null)
                queryValues.Add("ip", ip);

            if (account is not null)
                queryValues.Add("account", account);

            if (username is not null)
                queryValues.Add("username", username);

            if (connection is not null)
                queryValues.Add("connection", connection);

            if (queryValues.Count == 0)
                return RoutePath;

            string query = "";
            var keys = queryValues.Keys.ToArray();

            for (int i = 0; i < queryValues.Count; i++)
            {
                if (i < queryValues.Count - 1)
                    query += $"{keys[i]}={queryValues[keys[i]]}&";
                else
                    query += $"{keys[i]}={queryValues[keys[i]]}";
            }

            return $"{RoutePath}?{query}";
        }
    }

    public ConversionResult<RestResponse<string?>> GetSessions (string? connection, string? username, string? account, string? ip, string? uuid)
    =>  GetRest<RestResponse<string?>> (SessionRoute.GetRoutePath(connection, username, account, ip, uuid));
}
