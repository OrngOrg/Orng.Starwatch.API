using Newtonsoft.Json;
using Orng.Starwatch.API.Objects;

namespace Orng.Starwatch.API;

public partial class ApiClient
{
    public static class BanRoute
    {
        public const string RoutePath = "api/ban";
    }

    public ConversionResult<RestResponse<Ban?>> AddBan (Ban ban)
    => PostRestResponseSync<RestResponse<Ban?>> (BanRoute.RoutePath, JsonConvert.SerializeObject(ban));
}
