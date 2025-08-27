namespace BitzArt.ApiExceptions.AspNetCore;

/// <summary>
/// Allows configuring the API exception handler's behavior.
/// </summary>
public class ApiExceptionHandlerOptions
{
    /// <summary>
    /// Enables logging for all requests. <br />
    /// ⚠️ Will not log successful requests if ApiExceptionHandlingMiddleware is not enabled. <br />
    /// Default: false
    /// </summary>
    public bool LogRequests { get; set; } = false;

    /// <summary>
    /// Enables logging of handled exceptions. <br />
    /// Default: false
    /// </summary>
    public bool LogExceptions { get; set; } = false;

    /// <summary>
    /// Adds inner exceptions to ProblemDetails responses recursively. <br />
    /// Default: false
    /// </summary>
    public bool DisplayInnerExceptions { get; set; } = false;

    /// <summary>
    /// Disables using default values for 'type' field in the ProblemDetails response. <br />
    /// Default: false
    /// </summary>
    public bool DisableDefaultTypeValues { get; set; } = false;

    /// <summary>
    /// Disables adding the default 'status' values to the ProblemDetails response. <br />
    /// Default 'status' values are based on the http status codes. <br />
    /// Default: false
    /// </summary>
    public bool DisableDefaultProblemDetailsStatusValue { get; set; } = false;

    /// <summary>
    /// Disables logging of user errors (4xx status codes) as application errors. <br />
    /// Default: false
    /// </summary>
    public bool DisableLoggingUserErrors { get; set; } = false;
}
