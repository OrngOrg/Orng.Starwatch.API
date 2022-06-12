using Newtonsoft.Json;

namespace Orng.Starwatch.API
{
    public class RestResponse<T>
    {
        public RestStatus? Status { get; set; } = null;

        public string? Message { get; set; } = null;

        public string? Response { get; set; } = null;

        public T? Deserialized { get; set; } = default(T?);

        public T? TryDeserialize ()
        {
            if (Deserialized is not null)
            {
                return Deserialized;
            }

            if (Response is null)
            {
                return default(T?);
            }

            try
            {
                Deserialized = JsonConvert.DeserializeObject<T?>(Response);
                return Deserialized;
            }
            catch
            {
                return default(T?);
            }
        }
    }
}
