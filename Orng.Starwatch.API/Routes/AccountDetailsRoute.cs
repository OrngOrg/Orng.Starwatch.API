using Newtonsoft.Json;
using Orng.Starwatch.API.Objects;

namespace Orng.Starwatch.API;

public partial class ApiClient
{
    public static class AccountDetailsRoute
    {
        public const string RoutePath = "api/account/{0}";
    }

    public ConversionResult<RestResponse<Account?>> GetAccountDetails (string username)
    =>  GetRestResponseSync<RestResponse<Account?>> (string.Format(AccountDetailsRoute.RoutePath, username));

    public ConversionResult<RestResponse<bool?>> DelAccountDetails (string username)
    =>  DelRestResponseSync<RestResponse<bool?>> (string.Format(AccountDetailsRoute.RoutePath, username));

    public  ConversionResult<RestResponse<Account?>> PatchAccountDetails(string username, Account account)
    =>   PutRestResponseSync<RestResponse<Account?>>(string.Format(AccountDetailsRoute.RoutePath, username), JsonConvert.SerializeObject(account));
}
