using Orng.Starwatch.API.Objects;
using Newtonsoft.Json;

namespace Orng.Starwatch.API;

public partial class ApiClient
{
    public static class AnnouncementRoute
    {
        public const string RoutePath = "api/announcement";
    }

    public ConversionResult<RestResponse<Announcement[]?>> GetAnnouncements()
    =>  GetRestResponseSync<RestResponse<Announcement[]?>> (AnnouncementRoute.RoutePath);

    public ConversionResult<RestResponse<Announcement?>> GetAnnouncement(int i)
    =>  GetRestResponseSync<RestResponse<Announcement?>> ($"{AnnouncementRoute.RoutePath}?id={i}");

    public ConversionResult<RestResponse<Announcement?>> DelAnnouncement(int i)
    =>  DelRestResponseSync<RestResponse<Announcement?>> ($"{AnnouncementRoute.RoutePath}?id={i}");

    public ConversionResult<RestResponse<Announcement?>> PatchAnnouncement(Announcement announcement) 
    =>  PutRestResponseSync<RestResponse<Announcement?>> (AnnouncementRoute.RoutePath, JsonConvert.SerializeObject(announcement));

    public ConversionResult<RestResponse<object?>> PostAnnouncement(Announcement announcement)
    => PostRestResponseSync<RestResponse<object?>> (AnnouncementRoute.RoutePath, JsonConvert.SerializeObject(announcement));
}
