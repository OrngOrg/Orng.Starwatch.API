using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Orng.Starwatch.API.Objects;
using System.Linq;
using System.Collections.Generic;

namespace Orng.Starwatch.API.Tests.Routes;

[TestClass]
public class MetaGatewayRouteTests
{
    [TestMethod]
    public void GetGatewaysTest()
    {
        var cli = RouteTestConfig.GetSuperuserApiClient();
        var res = cli.GetGateways();
        System.Console.WriteLine(JsonConvert.SerializeObject(res));
        Assert.IsTrue(res.Success);
    }
}
