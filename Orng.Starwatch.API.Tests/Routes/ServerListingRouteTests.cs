using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Orng.Starwatch.API.Objects;
using System.Linq;
using System.Collections.Generic;

namespace Orng.Starwatch.API.Tests.Routes;

[TestClass]
public class ServerListingRouteTests
{
    [TestMethod]
    public void SendRconCommandTest()
    {
        var cli = RouteTestConfig.GetBotUserApiClient();
        var resp = cli.GetServerListing();

        Assert.IsTrue(resp.Success);
    }
}
