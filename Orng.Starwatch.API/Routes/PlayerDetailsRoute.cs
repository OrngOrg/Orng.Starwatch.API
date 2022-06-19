using Orng.Starwatch.API.Objects;

namespace Orng.Starwatch.API;

public partial class ApiClient
{
    public static class PlayerDetailsRoute
    {
        public const string RoutePath = "/player/:cid";

        public static string GetRoutePath (int cid)
        => RoutePath.Replace(":cid", cid.ToString());
    }

    public ConversionResult<RestResponse<Player?>> GetPlayerDetails (int cid)
    =>  GetRestResponseSync<RestResponse<Player?>> (PlayerDetailsRoute.GetRoutePath(cid));

    public ConversionResult<RestResponse<RconResponse>> KickPlayerByCid (int cid)
    =>  DelRestResponseSync<RestResponse<RconResponse>> (PlayerDetailsRoute.GetRoutePath(cid));
}
