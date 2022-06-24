using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Orng.Starwatch.API.Objects;
using System.Linq;
using System.Collections.Generic;

namespace Orng.Starwatch.API.Tests.Routes;

[TestClass]
public class MapSystemRouteTests
{
    [TestMethod]
    public void GetMapSystemTest()
    {
        var cli = RouteTestConfig.GetBotUserApiClient();
        Assert.Inconclusive();
    }
}
