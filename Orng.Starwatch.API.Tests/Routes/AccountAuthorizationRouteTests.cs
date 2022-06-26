using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Orng.Starwatch.API.Tests.Routes;

[TestClass]
public class AccountAuthorizationRouteTests
{
    [TestMethod]
    public void GetTest ()
    {
        var cli = RouteTestConfig.GetBotUserApiClient();
        var res = cli.TestAccountCredentials("bot_example", "postman");

        Assert.IsTrue(res.Success, JsonConvert.SerializeObject(res));
    }
}
