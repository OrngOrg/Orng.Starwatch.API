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
    => GetRest<RestResponse<Announcement[]?>> (AnnouncementRoute.RoutePath);

    public ConversionResult<RestResponse<Announcement?>> GetAnnouncement(int i)
    => GetRest<RestResponse<Announcement?>> ($"{AnnouncementRoute.RoutePath}?id={i}");

    public ConversionResult<RestResponse<Announcement?>> DeleteAnnouncement(int i)
    => DelRest<RestResponse<Announcement?>> ($"{AnnouncementRoute.RoutePath}?id={i}");

    public ConversionResult<RestResponse<Announcement?>> UpdateAnnouncement(Announcement announcement) 
    => PutRest<RestResponse<Announcement?>> (AnnouncementRoute.RoutePath, announcement);

    public ConversionResult<EmptyRestResponse> AddAnnouncement(Announcement announcement)
    => PostRest<EmptyRestResponse> (AnnouncementRoute.RoutePath, announcement);
}
