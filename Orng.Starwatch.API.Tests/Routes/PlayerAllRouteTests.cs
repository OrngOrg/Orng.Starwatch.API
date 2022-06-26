using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Orng.Starwatch.API.Objects;
using System.Linq;
using System.Collections.Generic;

namespace Orng.Starwatch.API.Tests.Routes;

[TestClass]
public class PlayerAllRouteTests
{
    [TestMethod]
    public void GetAllPlayersTest()
    {
        var cli = RouteTestConfig.GetBotUserApiClient();
        var res = cli.GetAllPlayers();
        System.Console.WriteLine(JsonConvert.SerializeObject(res));
        Assert.IsTrue(res.Success);
    }
}
