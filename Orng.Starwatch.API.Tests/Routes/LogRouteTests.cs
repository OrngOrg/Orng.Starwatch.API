using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Orng.Starwatch.API.Objects;
using System.Linq;
using System.Collections.Generic;

namespace Orng.Starwatch.API.Tests.Routes;

[TestClass]
public class LogRouteTests
{
    [TestMethod]
    public void DownloadLogTest()
    {
        var cli = RouteTestConfig.GetBotUserApiClient();
        Assert.Inconclusive("requires file i/o");
    }
}
