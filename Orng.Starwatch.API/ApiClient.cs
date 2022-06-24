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

    private HttpResponseMessage? CallClient (Func<HttpClient, HttpResponseMessage?> func)
    {
        try
        {
            using (var handler = new HttpClientHandler() { Credentials = credentials })
            {
                using (var client = new HttpClient(handler))
                {
                    client.Timeout = new TimeSpan(0, 0, timeoutSeconds);
                    var res = func(client);

                    if (enableVerboseDebug)
                        Console.WriteLine(JsonConvert.SerializeObject(res));

                    return res;
                }
            }
        }
        catch (Exception ex)
        {
            if (enableVerboseDebug)
                Console.WriteLine(ex.ToString());
            
            return null;
        }
    }

    private HttpResponseMessage? GetSync (string path)
    => CallClient((c) => c.GetAsync($"{baseUrl}/{path}").Result);

    /// <summary>
    /// Downloads a <paramref name="path"/> to a 
    /// file at <paramref name="output"/>, 
    /// using <paramref name="buffer"/> to move data from the HttpResponseMessage.
    /// </summary>
    private bool DownloadStreamSync (string path, string output, byte[] buffer)
    {
        if (File.Exists(output))
            File.Delete(output);

        var resp = CallClient((c) => c.GetAsync($"{baseUrl}/{path}").Result);

        if (resp is null)
            return false;

        try
        {
            Stream s = resp.Content.ReadAsStream();
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

    private HttpResponseMessage? DelSync(string path)
    => CallClient((c) => c.DeleteAsync($"{baseUrl}/{path}").Result);

    private HttpResponseMessage? PostSync(string path, string? body = null)
    {
        return body is not null
            ? CallClient((c) => c.PostAsync($"{baseUrl}/{path}", new StringContent(body, Encoding.UTF8, "application/json")).Result)
            : CallClient((c) => c.PostAsync($"{baseUrl}/{path}", null).Result);
    }

    private HttpResponseMessage? PatchSync(string path, string body)
    => CallClient((c) => c.PatchAsync($"{baseUrl}/{path}", new StringContent(body, Encoding.UTF8, "application/json")).Result);

    private HttpResponseMessage? PutSync(string path, string body)
    => CallClient((c) => c.PutAsync($"{baseUrl}/{path}", new StringContent(body, Encoding.UTF8, "application/json")).Result);

    

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

    private ConversionResult<T> PostRestResponseSync<T>(string path, string? body = null)
    => ConvertResponse<T>(PostSync(path, body));

    // starwatch seems to error when this is used for an actual patch request.
    private ConversionResult<T> PatchRestResponseSync<T>(string path, string body)
    => ConvertResponse<T>(PatchSync(path, body));

    private ConversionResult<T> PutRestResponseSync<T>(string path, string body)
    => ConvertResponse<T>(PutSync(path, body));
}
