using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Orng.Starwatch.API.Objects;
using System.Linq;
using System.Collections.Generic;

namespace Orng.Starwatch.API.Tests.Routes;

[TestClass]
public class BanListRouteTests
{
    [TestMethod]
    public void GetTest()
    {
        var cli = RouteTestConfig.GetBotUserApiClient();
        ConversionResult<RestResponse<Ban?>>? resps = null;
        var banIds = new List<long?>();

        for (int i=1; i<10; i++)
        {
            resps = cli.AddBan(new Ban
            {
                Moderator = "unit test",
                Reason = "Test reason",
                IP = $"1.1.2.{i}",
                ExpiresAt = 0
            });

            if (resps.Success && resps.Result is not null && resps.Result.Response is not null)
            {
                banIds.Add(resps.Result.Response.Ticket);
            }
        }

        var respx = cli.GetBans();
        System.Console.WriteLine(JsonConvert.SerializeObject(respx));

        Assert.IsTrue(respx.Success);
        Assert.IsTrue(respx.Result is not null && respx.Result.Response is not null && respx.Result.Response.Count == 10);
    }
}
