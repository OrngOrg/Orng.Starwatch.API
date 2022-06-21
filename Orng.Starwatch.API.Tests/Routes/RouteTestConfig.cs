namespace Orng.Starwatch.API.Tests.Routes;
public static class RouteTestConfig
{
    public const string BaseUrl = "http://localhost:8000";
    public const string BaseUsernameBotUser = "bot_example";
    public const string BasePasswordBotUser = "postman";

    public static ApiClient GetBotUserApiClient()
    => new(BaseUrl, BaseUsernameBotUser, BasePasswordBotUser);
}
