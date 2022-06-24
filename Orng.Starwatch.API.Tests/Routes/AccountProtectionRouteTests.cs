using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Orng.Starwatch.API.Objects;
using System.Linq;

namespace Orng.Starwatch.API.Tests.Routes;

[TestClass]
public class AccountProtectionRouteTests
{
    [TestMethod]
    public void GetTest()
    {
        var cli = RouteTestConfig.GetBotUserApiClient();

        // cleanup
        cli.DeleteWorldWhitelist("CelestialWorld:1:1:1:1:1");
        cli.DeleteAccount("test_user");
        cli.AddAccount(new Account { IsActive = true, IsAdmin = false, Name = "test_user", Password = "test_pass" });

        cli.AddWorldWhitelist("CelestialWorld:1:1:1:1:1", new OptionalProtectedWorld
        {
            AccountList = new System.Collections.Generic.HashSet<string>(),
            AllowAnonymous = true,
            Mode = WhitelistMode.Blacklist,
            Name = "Test world",
            Whereami = "CelestialWorld:1:1:1:1:1"
        });

        cli.AddAccountWhitelistOnWorld("CelestialWorld:1:1:1:1:1", "test_user");

        var res = cli.GetAccountWorldWhitelists("test_user");
        var resStr = JsonConvert.SerializeObject(res);
        Assert.IsTrue(res.Success, resStr);
        Assert.IsTrue(res.Result.Response.Where(x => x.Name == "Test world").Any(), resStr);
    }
}
