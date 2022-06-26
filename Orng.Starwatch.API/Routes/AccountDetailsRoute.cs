using Newtonsoft.Json;
using Orng.Starwatch.API.Objects;

namespace Orng.Starwatch.API;

public partial class ApiClient
{
    public static class AccountDetailsRoute
    {
        public const string RoutePath = "api/account/{0}";
    }

    public ConversionResult<RestResponse<Account?>> GetAccount (string username)
    => GetRest<RestResponse<Account?>> (string.Format(AccountDetailsRoute.RoutePath, username));

    public ConversionResult<RestResponse<bool?>> DeleteAccount (string username)
    => DelRest<RestResponse<bool?>> (string.Format(AccountDetailsRoute.RoutePath, username));

    public  ConversionResult<RestResponse<Account?>> UpdateAccount (string username, Account account)
    => PutRest<RestResponse<Account?>> (string.Format(AccountDetailsRoute.RoutePath, username), account);
}
