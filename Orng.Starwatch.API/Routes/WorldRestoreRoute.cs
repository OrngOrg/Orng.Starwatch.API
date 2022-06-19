using Newtonsoft.Json;
using Orng.Starwatch.API.Objects;

namespace Orng.Starwatch.API;

public partial class ApiClient
{
    /*
    public static class VersionRoute
    {
        public const string RouteBase = "api/version";
    }

    public ConversionResult<RestResponse<string>> GetVersion()
    => GetRestResponseSync<RestResponse<string>>(VersionRoute.RouteBase);*/

    public static class WorldRestoreRoute
    {
        public const string RoutePath = "api/world/:whereami/restore";

        public static string GetRoutePath (string whereami)
        => RoutePath.Replace(":whereami", whereami);
    }

    public class WorldRestorePatch
    {
        public string? Mirror { get; set; }
    }

    public ConversionResult<RestResponse<WorldRestore?>> GetWorldBackup (string whereami)
    =>  GetRestResponseSync<RestResponse<WorldRestore?>> (WorldRestoreRoute.GetRoutePath(whereami));

    public ConversionResult<RestResponse<WorldRestore?>> CreateWorldBackup (string whereami)
    => PostRestResponseSync<RestResponse<WorldRestore?>> (WorldRestoreRoute.GetRoutePath(whereami));

    public ConversionResult<RestResponse<bool?>> DeleteWorldBackup (string whereami)
    =>  DelRestResponseSync<RestResponse<bool?>> (WorldRestoreRoute.GetRoutePath(whereami));

    public ConversionResult<RestResponse<WorldRestore?>> RestoreWorld (string whereami, string backupMirror)
    =>  PutRestResponseSync<RestResponse<WorldRestore?>> (WorldRestoreRoute.GetRoutePath(whereami), JsonConvert.SerializeObject(new WorldRestorePatch { Mirror = backupMirror }));
}
