using Orng.Starwatch.API.Objects;

namespace Orng.Starwatch.API;

public partial class ApiClient
{
    public static class AccountProtectionRoute
    {
        public const string RouteBase = "api/account/{0}/protection";
    }

    public ConversionResult<RestResponse<IEnumerable<OptionalProtectedWorld>>> GetAccountProtections (string username)
    =>  GetRestResponseSync<RestResponse<IEnumerable<OptionalProtectedWorld>>> (string.Format(AccountProtectionRoute.RouteBase, username));
}
