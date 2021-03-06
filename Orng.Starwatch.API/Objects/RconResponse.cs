// See LICENSE.txt - Starwatch
namespace Orng.Starwatch.API.Objects;

/// <summary>
/// Response from the RCON client.
/// </summary>
public class RconResponse
{
    /// <summary>
    /// The command that was executed
    /// </summary>
    public string? Command { get; set; }

    /// <summary>
    /// The response from the rcon command (or the error message if <see cref="Success"/> is  false)
    /// </summary>
    public string? Message { get; set; }

    /// <summary>
    /// Did the rcon command succeed and get sent through?
    /// </summary>
    public bool? Success { get; set; }
}
