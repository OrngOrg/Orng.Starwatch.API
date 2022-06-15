using System.Net;
using System.Text;
using System.Web;
using Newtonsoft.Json;

namespace Orng.Starwatch.API;

public partial class ApiClient
{
    private readonly ICredentials credentials;

    public string BaseUrl { get; set; } = string.Empty;
    public bool EnableVerboseDebug { get; set; } = false;
    public int TimeoutSeconds { get; set; } = 10;

    public ApiClient(string baseUrl, string username, string password)
    {
        BaseUrl = baseUrl;
        credentials = new NetworkCredential(username, password);
    }

    private HttpResponseMessage? CallClient (Func<HttpClient, HttpResponseMessage?> func)
    {
        try
        {
            using (var handler = new HttpClientHandler() { Credentials = credentials })
            {
                using (var client = new HttpClient(handler))
                {
                    client.Timeout = new TimeSpan(0, 0, TimeoutSeconds);
                    var res = func(client);

                    if (EnableVerboseDebug)
                    {
                        Console.WriteLine(JsonConvert.SerializeObject(res));
                    }

                    return res;
                }
            }
        }
        catch (Exception ex)
        {
            if (EnableVerboseDebug)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }
    }

    private HttpResponseMessage? GetSync (string path)
    => CallClient((c) => c.GetAsync($"{BaseUrl}/{path}").Result);

    private string? GetStringSync (string path)
    {
        var resp = CallClient((c) => c.GetAsync($"{BaseUrl}/{path}").Result);

        if (resp is null)
            return null;

        try
        {
            string r = resp.Content.ReadAsStringAsync().Result;
            return r;
        }
        catch
        {
            return null;
        }
    }

    private HttpResponseMessage? DelSync(string path)
    => CallClient((c) => c.DeleteAsync($"{BaseUrl}/{path}").Result);

    private HttpResponseMessage? PostSync(string path, string body)
    => CallClient((c) => c.PostAsync($"{BaseUrl}/{path}", new StringContent(body, Encoding.UTF8, "application/json")).Result);

    private HttpResponseMessage? PatchSync(string path, string body)
    => CallClient((c) => c.PatchAsync($"{BaseUrl}/{path}", new StringContent(body, Encoding.UTF8, "application/json")).Result);

    private HttpResponseMessage? PutSync(string path, string body)
    => CallClient((c) => c.PutAsync($"{BaseUrl}/{path}", new StringContent(body, Encoding.UTF8, "application/json")).Result);

    public class ConversionResult<T>
    {
        public bool Success { get; set; } = false;
        public T? Result { get; set; } = default;
        public Exception? Exception { get; set; } = null;
        public string Raw { get; set; } = string.Empty;

        public ConversionResult (bool success = false, T? result = default, string raw = "", Exception? exception = null)
        {
            Success = success;
            Result = result;
            Raw = raw;
            Exception = exception;
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

    private ConversionResult<T> GetRestResponseSync<T>(string path)
    => ConvertResponse<T>(GetSync(path));

    private ConversionResult<T> DelRestResponseSync<T>(string path)
    => ConvertResponse<T>(DelSync(path));

    private ConversionResult<T> PostRestResponseSync<T>(string path, string body)
    => ConvertResponse<T>(PostSync(path, body));

    // starwatch seems to error when this is used for an actual patch request.
    private ConversionResult<T> PatchRestResponseSync<T>(string path, string body)
    => ConvertResponse<T>(PatchSync(path, body));

    private ConversionResult<T> PutRestResponseSync<T>(string path, string body)
    => ConvertResponse<T>(PutSync(path, body));
}
