// See LICENSE.txt - Starwatch

namespace Orng.Starwatch.API;

/// <summary>
/// RestResponse from Starwatch
/// </summary>
public class RestResponse<T>
{
    public RestStatus? Status { get; set; } = null;

    public string? Message { get; set; } = null;

    public T? Response { get; set; } = default;
}
