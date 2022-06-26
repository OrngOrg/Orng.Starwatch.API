using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Orng.Starwatch.API;

public partial class ApiClient
{
    public static class ServerRoute
    {
        public const string RoutePath = "api/server";
    }

    public class ServerRoutePayload
    {
        public bool? AllowAnonymousConnections { get; set; }
        public bool? AllowAssetsMismatch { get; set; }
        public int? MaxPlayers { get; set; }
        public string? ServerName { get; set; }
    }

    public ConversionResult<RestResponse<JObject?>> UpdateServerConfig (ServerRoutePayload payload)
    =>  PutRest<RestResponse<JObject?>> (ServerRoute.RoutePath, payload);

    public ConversionResult<EmptyRestResponse> RestartServer ()
    =>  DelRest<EmptyRestResponse> (ServerRoute.RoutePath);
}
