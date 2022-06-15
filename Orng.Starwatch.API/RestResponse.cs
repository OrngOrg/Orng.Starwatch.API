namespace Orng.Starwatch.API;

public class RestResponse<T>
{
    public RestStatus? Status { get; set; } = null;

    public string? Message { get; set; } = null;

    public T? Response { get; set; } = default;
}
