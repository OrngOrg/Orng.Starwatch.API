using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Orng.Starwatch.API.Objects;

namespace Orng.Starwatch.API.Tests.Routes;

[TestClass]
public class AccountDetailsRouteTests
{
    [TestMethod]
    public void GetTest()
    {
        var cli = RouteTestConfig.GetBotUserApiClient();

        cli.DeleteAccount("test_user"); // cleanup

        var res = cli.AddAccount(new Account { IsActive = true, IsAdmin = false, Name = "test_user", Password = "test_pass" });
        Assert.IsTrue(res.Success, JsonConvert.SerializeObject(res));

        var res2 = cli.GetAccount("test_user");
        var res2str = JsonConvert.SerializeObject(res2);
        Assert.IsTrue(res2.Success, res2str);
        Assert.IsTrue(res2.Result.Response.Name.Equals("test_user"), res2str);
    }

    [TestMethod]
    public void PatchTest ()
    {
        var cli = RouteTestConfig.GetBotUserApiClient();

        cli.DeleteAccount("test_user"); // cleanup
        cli.AddAccount(new Account { IsActive = true, IsAdmin = false, Name = "test_user", Password = "test_pass" });

        var res4 = cli.UpdateAccount("test_user", new Account { IsActive = false });
        var res4str = JsonConvert.SerializeObject(res4);
        Assert.IsTrue(res4.Success, res4str);
        Assert.IsTrue(res4.Result.Response.IsActive == false, res4str);
    }

    [TestMethod]
    public void DelTest ()
    {
        var cli = RouteTestConfig.GetBotUserApiClient();

        cli.AddAccount(new Account { IsActive = true, IsAdmin = false, Name = "test_user", Password = "test_pass" });

        var res3 = cli.DeleteAccount("test_user");
        var res3str = JsonConvert.SerializeObject(res3);
        Assert.IsTrue(res3.Success, res3str);
        Assert.IsTrue(res3.Result.Response == true, res3str);
    }
}
