using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Orng.Starwatch.API;
public class HandledHttpResponse
{
    public bool Success { get; set; } = false;
    public HttpResponseMessage? Response { get; set; } = null;
    public WebException? WebException { get; set; } = null;
    public Exception? FallbackException { get; set; } = null;

    public HandledHttpResponse (HttpResponseMessage? resp, WebException? wex, Exception? ex)
    {
        if (resp is not null)
            Success = true;

        Response = resp;
        WebException = wex;
        FallbackException = ex;

        if (WebException is not null)
            ReadWebException();
    }

    private void ReadWebException ()
    {
        // Do things here.
    }
}
