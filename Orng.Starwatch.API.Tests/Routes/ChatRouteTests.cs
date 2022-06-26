using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Orng.Starwatch.API.Objects;
using System.Linq;
using System.Collections.Generic;

namespace Orng.Starwatch.API.Tests.Routes;

[TestClass]
public class ChatRouteTests
{
    [TestMethod]
    public void SendChatMessageTest()
    {
        var cli = RouteTestConfig.GetBotUserApiClient();
        var resp = cli.SendChatMessage("Hello world");
        Assert.IsTrue(resp.Success);
    }
}
