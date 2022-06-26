using Orng.Starwatch.API.Objects;
using Newtonsoft.Json;

namespace Orng.Starwatch.API;

public partial class ApiClient
{
    public static class AccountRoute
    {
        public const string RoutePath = "api/account";
    }

    public ConversionResult<RestResponse<Account?>> AddAccount (Account account)
    => PostRest<RestResponse<Account?>> (AccountRoute.RoutePath, account);
}
