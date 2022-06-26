using Orng.Starwatch.API.Objects;

namespace Orng.Starwatch.API;

public partial class ApiClient
{
    public static class BanDetailsRoute
    {
        public const string RoutePath = "api/ban/{0}";
    }

    public ConversionResult<RestResponse<Ban?>> GetBan (long? id)
    =>  GetRest<RestResponse<Ban?>> (string.Format(BanDetailsRoute.RoutePath, id));

    public ConversionResult<RestResponse<bool?>> DeleteBan (long? id)
    =>  DelRest<RestResponse<bool?>> (string.Format(BanDetailsRoute.RoutePath, id));
}
