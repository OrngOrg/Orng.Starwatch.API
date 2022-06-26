using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Orng.Starwatch.API.Objects;
using System.Linq;

namespace Orng.Starwatch.API.Tests.Routes;

[TestClass]
public class BanDetailsRouteTests
{
    [TestMethod]
    public void GetTest()
    {
        var cli = RouteTestConfig.GetBotUserApiClient();
        var res = cli.AddBan(new Ban
        {
            Moderator = "unit test",
            Reason = "Test reason",
            IP = "1.1.1.1",
            ExpiresAt = 0
        });

        var resStr = JsonConvert.SerializeObject(res);

        Assert.IsTrue(res.Success, resStr);

        var ban = cli.GetBan(res.Result.Response.Ticket);
        var banStr = JsonConvert.SerializeObject(ban);
        Assert.IsTrue(ban.Success, banStr);
        Assert.IsTrue(ban.Result.Response.IP == "1.1.1.1", banStr);
    }

    [TestMethod]
    public void DelTest()
    {
        var cli = RouteTestConfig.GetBotUserApiClient();

        var res = cli.AddBan(new Ban
        {
            Moderator = "unit test",
            Reason = "Test reason",
            IP = "1.1.1.1"
        });

        var del = cli.DeleteBan(res.Result.Response.Ticket);
        var delStr = JsonConvert.SerializeObject(del);
        Assert.IsTrue(del.Success, delStr);
    }
}
