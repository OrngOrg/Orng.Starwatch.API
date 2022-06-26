using Newtonsoft.Json;
using Orng.Starwatch.API.Objects;

namespace Orng.Starwatch.API;

public partial class ApiClient
{
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
    =>  GetRest<RestResponse<WorldRestore?>> (WorldRestoreRoute.GetRoutePath(whereami));

    public ConversionResult<RestResponse<WorldRestore?>> CreateWorldBackup (string whereami)
    => PostRest<RestResponse<WorldRestore?>> (WorldRestoreRoute.GetRoutePath(whereami));

    public ConversionResult<RestResponse<bool?>> DeleteWorldBackup (string whereami)
    =>  DelRest<RestResponse<bool?>> (WorldRestoreRoute.GetRoutePath(whereami));

    public ConversionResult<RestResponse<WorldRestore?>> RestoreWorld (string whereami, string backupMirror)
    =>  PutRest<RestResponse<WorldRestore?>> (WorldRestoreRoute.GetRoutePath(whereami), new WorldRestorePatch { Mirror = backupMirror });
}
