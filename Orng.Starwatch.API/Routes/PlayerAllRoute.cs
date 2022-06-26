using Orng.Starwatch.API.Objects;

namespace Orng.Starwatch.API;

public partial class ApiClient
{
    public static class PlayerAllRoute
    {
        public const string RoutePath = "api/player/all";
    }

    public ConversionResult<RestResponse<List<Player>?>> GetAllPlayers()
    =>  GetRest<RestResponse<List<Player>?>> (PlayerAllRoute.RoutePath);
}
