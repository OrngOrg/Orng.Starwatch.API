using Orng.Starwatch.API.Objects;

namespace Orng.Starwatch.API;

public partial class ApiClient
{
    public static class AccountProtectionRoute
    {
        public const string RoutePath = "api/account/{0}/protection";
    }

    public ConversionResult<RestResponse<List<OptionalProtectedWorld>?>> GetAccountWorldWhitelists (string username)
    => GetRest<RestResponse<List<OptionalProtectedWorld>?>> (string.Format(AccountProtectionRoute.RoutePath, username));
}
