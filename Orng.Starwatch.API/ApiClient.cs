using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace Orng.Starwatch.API
{
    public partial class ApiClient
    {
        private ICredentials credentials;

        public string BaseUrl { get; set; } = string.Empty;

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
                        return func(client);
                    }
                }
            }
            catch
            {
                return null;
            }
        }

        private HttpResponseMessage? GetSync (string path)
        => CallClient((c) => c.GetAsync($"{BaseUrl}/{path}").Result);

        private HttpResponseMessage? DelSync(string path)
        => CallClient((c) => c.DeleteAsync($"{BaseUrl}/{path}").Result);

        private HttpResponseMessage? PostSync(string path, string body)
        => CallClient((c) => c.PostAsync($"{BaseUrl}/{path}", new StringContent(body, Encoding.UTF8, "application/json")).Result);

        private HttpResponseMessage? PatchSync(string path, string body)
        => CallClient((c) => c.PatchAsync($"{BaseUrl}/{path}", new StringContent(body, Encoding.UTF8, "application/json")).Result);

        private HttpResponseMessage? PutSync(string path, string body)
        => CallClient((c) => c.PutAsync($"{BaseUrl}/{path}", new StringContent(body, Encoding.UTF8, "application/json")).Result);
    }
}
