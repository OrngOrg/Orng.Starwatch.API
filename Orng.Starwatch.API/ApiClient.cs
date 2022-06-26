using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace Orng.Starwatch.API;

/// <summary>
/// Starwatch API Client
/// </summary>
public partial class ApiClient
{
    private readonly ICredentials credentials;
    private readonly string baseUrl;

    /// <summary>
    /// Outputs debug statements through Console.WriteLine.
    /// </summary>
    public bool enableVerboseDebug = false;

    /// <summary>
    /// Connection timeout in seconds.
    /// </summary>
    public int timeoutSeconds = 10;

    public ApiClient(string baseUrl, string username, string password)
    {
        this.baseUrl = baseUrl;
        credentials = new NetworkCredential(username, password);
    }

    private HandledHttpResponse HttpRequest (HttpMethod method, string path, params object[] body)
    {
        if (body.Length > 1)
            throw new ArgumentOutOfRangeException(nameof(body), "Only 0-1 body parameters are expected.");

        using (var handler = new HttpClientHandler() { Credentials = credentials })
        using (var client = new HttpClient(handler))
        {
            client.Timeout = new TimeSpan(0, 0, timeoutSeconds);
            var req = new HttpRequestMessage(method, $"{baseUrl}/{path}");

            if (body.Length == 1)
                req.Content = new StringContent(JsonConvert.SerializeObject(body[0]), Encoding.UTF8, "application/json");

            HttpResponseMessage? resp = null;
            WebException? wex = null;
            Exception? ex = null;

            try                       { resp = client.Send(req); }
            catch (WebException _wex) { wex  = _wex; }
            catch (Exception _ex)     { ex   = _ex; }

            return new HandledHttpResponse(resp, wex, ex);
        }
    }

    private ConversionResult<T> RestRequest<T> (HttpMethod method, string path, params object[] body)
    {
        var resp = HttpRequest(method, path, body);

        return resp.Success 
            ? ConvertResponse<T>(resp.Response) 
            : ConvertResponse<T>(null);
    }

    private ConversionResult<T> GetRest<T>(string path, params object[] body)
    => RestRequest<T>(HttpMethod.Get, path, body);

    private ConversionResult<T> PostRest<T>(string path, params object[] body)
    => RestRequest<T>(HttpMethod.Post, path, body);

    private ConversionResult<T> DelRest<T>(string path, params object[] body)
    => RestRequest<T>(HttpMethod.Delete, path, body);

    private ConversionResult<T> PutRest<T>(string path, params object[] body)
    => RestRequest<T>(HttpMethod.Put, path, body);

    private ConversionResult<T> PatchRest<T>(string path, params object[] body)
    => RestRequest<T>(HttpMethod.Patch, path, body);

    /// <summary>
    /// Downloads a <paramref name="path"/> to a 
    /// file at <paramref name="output"/>, 
    /// using <paramref name="buffer"/> to move data from the HttpResponseMessage.
    /// </summary>
    private bool DownloadStreamSync (string path, string output, byte[] buffer)
    {
        if (File.Exists(output))
            File.Delete(output);

        var resp = HttpRequest(HttpMethod.Get, $"{path}");

        if (resp is null || !resp.Success || resp.Response is null)
            return false;

        try
        {
            Stream s = resp.Response.Content.ReadAsStream();
            FileStream fs = File.OpenWrite(output);
            int bytesRead = s.Read(buffer, 0, buffer.Length);
            
            while (bytesRead > 0)
            {
                fs.Write(buffer, 0, bytesRead);
                bytesRead = s.Read(buffer, 0, buffer.Length);
            }

            fs.Close();
            s.Close();

            return true;
        }
        catch (Exception ex)
        {
            if (enableVerboseDebug)
                Console.WriteLine($"Exception with DownloadStreamSync: {ex}");

            return false;
        }
    }

    private ConversionResult<T> ConvertResponse<T>(HttpResponseMessage? resp, Action<Exception>? failCallback = null)
    {
        if (resp is null)
            return new ConversionResult<T>();

        string content = resp.Content.ReadAsStringAsync().Result;

        try
        {
            T? val = JsonConvert.DeserializeObject<T>(content);
            return new ConversionResult<T>(true, val, content);
        }
        catch (Exception ex)
        {
            if (failCallback is not null)
                failCallback(ex);

            return new ConversionResult<T>(false, default, content, ex);
        }
    }
}
