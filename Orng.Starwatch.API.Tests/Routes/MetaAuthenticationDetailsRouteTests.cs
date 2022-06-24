using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Orng.Starwatch.API.Objects;
using System.Linq;
using System.Collections.Generic;

namespace Orng.Starwatch.API.Tests.Routes;

[TestClass]
public class MetaAuthenticationDetailsRouteTests
{
    [TestMethod]
    public void GetMetaAuthenticationDetailsTest()
    {
        var cli = RouteTestConfig.GetSuperuserApiClient();
        var res = cli.GetStarwatchSessionDetails();
        System.Console.WriteLine(JsonConvert.SerializeObject(res));
        Assert.IsTrue(res.Success);

        var cli2 = RouteTestConfig.GetBotUserApiClient();
        cli2.SendChatMessage("Test");

        res = cli.GetStarwatchSessionDetails(RouteTestConfig.BaseUsernameBotUser);
        System.Console.WriteLine(JsonConvert.SerializeObject(res));
        Assert.IsTrue(res.Success);
    }
}
