namespace Orng.Starwatch.API;

public partial class ApiClient
{
    public static class LogRoute
    {
        public const string RouteBase = "log/{0}";
    }

    public string? GetLog(int num = 0)
    => GetStringSync(string.Format(LogRoute.RouteBase, num));
}
