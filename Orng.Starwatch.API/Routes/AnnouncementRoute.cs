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

    public ConversionResult<RestResponse<Announcement?>> DeleteAnnouncement(int i)
    =>  DelRestResponseSync<RestResponse<Announcement?>> ($"{AnnouncementRoute.RoutePath}?id={i}");

    public ConversionResult<RestResponse<Announcement?>> UpdateAnnouncement(Announcement announcement) 
    =>  PutRestResponseSync<RestResponse<Announcement?>> (AnnouncementRoute.RoutePath, JsonConvert.SerializeObject(announcement));

    public ConversionResult<EmptyRestResponse> AddAnnouncement(Announcement announcement)
    => PostRestResponseSync<EmptyRestResponse> (AnnouncementRoute.RoutePath, JsonConvert.SerializeObject(announcement));
}
