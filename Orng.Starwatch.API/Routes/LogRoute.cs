namespace Orng.Starwatch.API;

public partial class ApiClient
{
    public static class LogRoute
    {
        public const string RoutePath = "log/{0}";
    }

    public string? GetLog(int num = 0)
    => GetStringSync(string.Format(LogRoute.RoutePath, num));
}
