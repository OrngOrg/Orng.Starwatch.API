// See LICENSE.txt - Starwatch

namespace Orng.Starwatch.API;

/// <summary>
/// RestResponse from Starwatch with no Response parameter expected.
/// </summary>
public class EmptyRestResponse
{
    public RestStatus? Status { get; set; } = null;

    public string? Message { get; set; } = null;
}
