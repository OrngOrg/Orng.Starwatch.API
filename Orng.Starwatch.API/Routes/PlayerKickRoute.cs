using Orng.Starwatch.API.Objects;

namespace Orng.Starwatch.API;

public partial class ApiClient
{
    public static class PlayerKickRoute
    {
        public const string RoutePath = "api/player/kick";

        public static string GetRoutePath (Player player)
        {
            var queryValues = new Dictionary<string, string>();

            if (player.UUID is not null)
                queryValues.Add("uuid", player.UUID);

            if (player.IP is not null)
                queryValues.Add("ip", player.IP);

            if (player.AccountName is not null)
                queryValues.Add("account", player.AccountName);

            if (player.Username is not null)
                queryValues.Add("username", player.Username);

            if (player.Nickname is not null)
                queryValues.Add("nickname", player.Nickname);

            if (player.Connection is not null)
            {
                string? c = player.Connection.ToString(); // int.ToString -> string?, so .NET 6 warns about possible null dereference if you don't check again.
                if (c is not null)
                    queryValues.Add("cid", c);
            }

            if (queryValues.Count == 0)
                return RoutePath;

            string query = "";
            var keys = queryValues.Keys.ToArray();

            for (int i=0; i<queryValues.Count; i++)
            {
                if (i < queryValues.Count - 1)
                    query += $"{keys[i]}={queryValues[keys[i]]}&";
                else
                    query += $"{keys[i]}={queryValues[keys[i]]}";
            }

            return $"{RoutePath}?{query}";
        }
    }

    public ConversionResult<RestResponse<PlayerKickResponse>> KickPlayersByQuery (Player player)
    =>  DelRestResponseSync<RestResponse<PlayerKickResponse>> (PlayerKickRoute.GetRoutePath(player));
}
