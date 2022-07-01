using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Orng.Starwatch.API.Objects;
using System.Linq;
using System.Collections.Generic;

namespace Orng.Starwatch.API.Tests.Routes;

[TestClass]
public class WorldPlayerRouteTests
{
    /*[TestMethod]
    public void SendRconCommandTest()
    {
        var cli = RouteTestConfig.GetBotUserApiClient();
        var resp = cli.SendRconCommand("say Test");

        Assert.IsTrue(resp.Success);
    }*/

    [TestMethod]
    public void GetPlayersOnWorldTest() => Assert.Inconclusive();
}
