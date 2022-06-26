using Newtonsoft.Json;

namespace Orng.Starwatch.API;

public partial class ApiClient
{
    public static class AccountAuthorizationRoute
    {
        public const string RoutePath = "api/account/{0}/authorize";

        public static string GetRoutePath (string username)
        => string.Format(RoutePath, username);
    }

    private class AccountAuthorizationRoutePayload
    {
        public string Hash { get; set; } = string.Empty;

        public AccountAuthorizationRoutePayload(string hash) => Hash = hash;
    }

    public ConversionResult<RestResponse<bool?>> TestAccountCredentials (string username, string password)
    {
        string hash = BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt(), true);
        var payload = new AccountAuthorizationRoutePayload(hash);
        return PostRest<RestResponse<bool?>>(AccountAuthorizationRoute.GetRoutePath(username), payload);
        //return SendRestRequest<RestResponse<bool?>>(AccountAuthorizationRoute.GetRoutePath(username), payload, HttpMethod.Post);
    }

    //private ConversionResult<T> SendRestRequest<T>(string v, AccountAuthorizationRoutePayload payload, HttpMethod post) => throw new NotImplementedException();
}
