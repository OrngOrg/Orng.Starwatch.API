using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Orng.Starwatch.API.Objects;
using System.Linq;
using System.Collections.Generic;

namespace Orng.Starwatch.API.Tests.Routes;

[TestClass]
public class ServerUptimeRouteTests
{
    [TestMethod]
    public void GetServerUptimeTest()
    {
        var cli = RouteTestConfig.GetBotUserApiClient();
        var resp = cli.GetServerUptime();

        System.Console.WriteLine(JsonConvert.SerializeObject(resp));
        Assert.IsTrue(resp.Success);
    }
}
