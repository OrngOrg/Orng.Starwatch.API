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
    public void GetServerListingTest()
    {
        var cli = RouteTestConfig.GetBotUserApiClient();
        var resp = cli.GetServerListing();

        System.Console.WriteLine(JsonConvert.SerializeObject(resp));
        Assert.IsTrue(resp.Success);
    }
}
