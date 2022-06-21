namespace Orng.Starwatch.API;

public partial class ApiClient
{
    public static class LogRoute
    {
        public const string RoutePath = "log/{0}";
    }

    public bool DownloadLog(string path, byte[] buffer, int num = 0)
    => DownloadStreamSync(string.Format(LogRoute.RoutePath, num), path, buffer);
}
