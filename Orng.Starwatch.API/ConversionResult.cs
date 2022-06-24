namespace Orng.Starwatch.API;

/// <summary>
/// ConversionResult of a JsonConvert.DeserializeObject call for a T parameter.
/// </summary>
public class ConversionResult<T>
{
    public bool Success { get; set; } = false;
    public T? Result { get; set; } = default;
    public Exception? Exception { get; set; } = null;

    /// <summary>
    /// Original Content of the HttpResponse
    /// </summary>
    public string Raw { get; set; } = string.Empty;

    public ConversionResult(bool success = false, T? result = default, string raw = "", Exception? exception = null)
    {
        Success = success;
        Result = result;
        Raw = raw;
        Exception = exception;
    }
}
