using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Orng.Starwatch.API.Objects;
using System.Linq;

namespace Orng.Starwatch.API.Tests.Routes;

[TestClass]
public class AccountRouteTests
{
    [TestMethod]
    public void PostTest()
    {
        var cli = RouteTestConfig.GetBotUserApiClient();
        cli.DelAccountDetails("test_user");
        var res = cli.PostAccount(new Account { IsActive = true, IsAdmin = false, Name = "test_user", Password = "test_pass" });
        var resStr = JsonConvert.SerializeObject(res);
        Assert.IsTrue(res.Success == true, resStr);
        Assert.IsTrue(res.Result.Response.IsActive == true, resStr);
        Assert.IsTrue(res.Result.Response.IsAdmin == false, resStr);
        Assert.IsTrue(res.Result.Response.Name == "test_user", resStr);
        Assert.IsTrue(res.Result.Response.Password == null || res.Result.Response.Password == string.Empty, resStr);
    }
}
