using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Orng.Starwatch.API.Objects;
using System.Linq;
using System.Collections.Generic;

namespace Orng.Starwatch.API.Tests.Routes;

[TestClass]
public class MapRouteTests
{
    [TestMethod]
    public void GetMapTest()
    {
        var cli = RouteTestConfig.GetBotUserApiClient();
        var resp = cli.GetMap(-1000, 1000, -1000, 1000);

        Assert.IsTrue(resp.Success);
    }
}
