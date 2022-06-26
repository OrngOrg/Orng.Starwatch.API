using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Orng.Starwatch.API.Objects;
using System.Linq;

namespace Orng.Starwatch.API.Tests.Routes;

[TestClass]
public class AnnouncementRouteTests
{
    [TestMethod]
    public void GetAnnouncementsTest()
    {
        var cli = RouteTestConfig.GetBotUserApiClient();
        var res = cli.GetAnnouncements();
        var resStr = JsonConvert.SerializeObject(res);

        System.Console.WriteLine(resStr);

        Assert.IsTrue(res.Success);
    }

    [TestMethod]
    public void GetAnnouncementTest()
    {
        var cli = RouteTestConfig.GetBotUserApiClient();
        var res = cli.GetAnnouncement(0);
        var resStr = JsonConvert.SerializeObject(res);

        System.Console.WriteLine(resStr);

        Assert.IsTrue(res.Success);
    }

    [TestMethod]
    public void PostAnnouncementTest()
    {
        var cli = RouteTestConfig.GetBotUserApiClient();
        var res = cli.AddAnnouncement(new Announcement
        {
            Enabled = true,
            Interval = 1000d,
            Message = "Test message"
        });


        var resStr = JsonConvert.SerializeObject(res);

        System.Console.WriteLine(resStr);

        Assert.IsTrue(res.Success);

        var res2 = cli.GetAnnouncements();
        cli.DeleteAnnouncement(res2.Result.Response.Length - 1);
    }

    [TestMethod]
    public void DelAnnouncementTest() => PostAnnouncementTest();

    [TestMethod]
    public void PatchAnnouncementTest()
    {
        var cli = RouteTestConfig.GetBotUserApiClient();
        var res = cli.AddAnnouncement(new Announcement
        {
            Enabled = true,
            Interval = 1000d,
            Message = "Test message"
        });


        var resStr = JsonConvert.SerializeObject(res);

        System.Console.WriteLine(resStr);

        Assert.IsTrue(res.Success);

        var res2 = cli.GetAnnouncements();
        cli.UpdateAnnouncement(new Announcement
        {
            Id = res2.Result.Response.Length - 1,
            Message = "Test message 2"
        });

        res2 = cli.GetAnnouncements();

        Assert.IsTrue(res2.Result.Response[res2.Result.Response.Length - 1].Message == "Test message 2");

        cli.DeleteAnnouncement(res2.Result.Response.Length - 1);
    }
}
