using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Orng.Starwatch.API.Objects;
using System.Linq;
using System.Collections.Generic;

namespace Orng.Starwatch.API.Tests.Routes;

[TestClass]
public class MetaEndpointsRouteTests
{
    [TestMethod]
    public void GetMetaAuthenticationTest()
    {
        var cli = RouteTestConfig.GetSuperuserApiClient();
        var res = cli.GetRestEndpoints();
        System.Console.WriteLine(JsonConvert.SerializeObject(res));
        Assert.IsTrue(res.Success);
    }
}
