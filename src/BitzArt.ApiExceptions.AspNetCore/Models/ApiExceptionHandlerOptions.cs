namespace BitzArt.ApiExceptions.AspNetCore;

public class ApiExceptionHandlerOptions
{
    /// <summary>
    /// Disables using default values for 'type' field in the response.
    /// </summary>
    public bool DisableDefaultTypeValues { get; set; } = false;

    /// <summary>
    /// Enables logging for all requests.
    /// Will not log successful requests if ApiExceptionHandlingMiddleware is not enabled.
    /// </summary>
    public bool LogRequests { get; set; } = false;

    /// <summary>
    /// Enables logging of handled exceptions.
    /// </summary>
    public bool LogExceptions { get; set; } = false;

    /// <summary>
    /// Adds inner exceptions to error responses recursively.
    /// </summary>
    public bool DisplayInnerExceptions { get; set; } = false;
}
