using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Orng.Starwatch.API.Objects;
using System.Linq;
using System.Collections.Generic;

namespace Orng.Starwatch.API.Tests.Routes;

[TestClass]
public class BanRouteTests
{
    [TestMethod]
    public void AddBanTest()
    {
        var cli = RouteTestConfig.GetBotUserApiClient();
        var respBan = cli.AddBan(new Ban { IP = "1.2.3.4", Reason = "Test!", ExpiresAt = 0, Moderator = "Unit Test" });
        Assert.IsTrue(respBan.Success);
        Assert.IsTrue(respBan.Result is not null && respBan.Result.Response is not null && respBan.Result.Response.ExpiresAt == 0);
    }
}
