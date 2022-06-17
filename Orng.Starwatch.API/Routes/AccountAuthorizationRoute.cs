using Newtonsoft.Json;
namespace Orng.Starwatch.API;

public partial class ApiClient
{
    public static class AccountAuthorizationRoute
    {
        public const string RoutePath = "api/account/{0}/authorize";
    }

    private class AccountAuthorizationRoutePayload
    {
        public string Hash { get; set; } = string.Empty;

        public AccountAuthorizationRoutePayload(string hash) => Hash = hash;
    }

    public ConversionResult<RestResponse<bool?>> PostAccountAuthorization (string username, string password)
    {
        string hash = BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt(), true);
        string data = JsonConvert.SerializeObject(new AccountAuthorizationRoutePayload(hash));
        return PostRestResponseSync<RestResponse<bool?>>(string.Format(AccountAuthorizationRoute.RoutePath, username), data);
    }
}
