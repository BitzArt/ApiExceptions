using BitzArt.ApiExceptions;
using Keys = BitzArt.ApiExceptions.ApiExceptionPayload.Keys;

namespace BitzArt;

/// <summary>
/// API Exception base class.
/// </summary>
public partial class ApiException : ApiExceptionBase
{
    /// <inheritdoc/>
    public ApiException
        (string message = "Unexpected Error",
        ApiStatusCode statusCode = ApiStatusCode.Error,
        string? errorType = null,
        ApiExceptionPayload? payload = null,
        Exception? innerException = null)
        : base(message, statusCode, errorType, payload, innerException)
    { }

    /// <inheritdoc/>
    public ApiException
        (string message,
        int statusCode,
        string? errorType = null,
        ApiExceptionPayload? payload = null,
        Exception? innerException = null)
        : base(message, statusCode, errorType, payload, innerException)
    { }
}

/// <summary>
/// API Exception base class.
/// </summary>
[Obsolete($"Use {nameof(ApiException)} instead.")]
public abstract class ApiExceptionBase : Exception
{
    /// <summary>
    /// API Status code
    /// </summary>
    public int StatusCode { get; set; }

    /// <summary>
    /// API Exception Payload
    /// </summary>
    public ApiExceptionPayload Payload { get; }

    /// <summary>
    /// Creates a new instance of <see cref="ApiExceptionBase"/>
    /// </summary>
    /// <param name="message"></param>
    /// <param name="statusCode"></param>
    /// <param name="errorType"></param>
    /// <param name="payload"></param>
    /// <param name="innerException"></param>
    protected ApiExceptionBase
        (
        string message = "Unexpected Error",
        ApiStatusCode statusCode = ApiStatusCode.Error,
        string? errorType = null,
        ApiExceptionPayload? payload = null,
        Exception? innerException = null)
        : this(message, (int)statusCode, errorType, payload, innerException)
    { }

    /// <summary>
    /// Creates a new instance of <see cref="ApiExceptionBase"/>
    /// </summary>
    /// <param name="message"></param>
    /// <param name="statusCode"></param>
    /// <param name="errorType"></param>
    /// <param name="payload"></param>
    /// <param name="innerException"></param>
    protected ApiExceptionBase
        (string message,
        int statusCode,
        string? errorType = null,
        ApiExceptionPayload? payload = null,
        Exception? innerException = null)
        : base(message, innerException)
    {
        StatusCode = statusCode;
        Payload = payload ?? new();
        if (errorType is not null) ErrorType = errorType;
    }

    /// <summary>
    /// Error type
    /// </summary>
    public string? ErrorType
    {
        get => Payload.GetDataEntry<string?>(Keys.ErrorType);
        set => Payload.AddData(Keys.ErrorType, value!);
    }

    /// <summary>
    /// Additional error details
    /// </summary>
    public string? Detail
    {
        get => Payload.GetDataEntry<string?>(Keys.Detail);
        set => Payload.AddData(Keys.Detail, value!);
    }

    /// <summary>
    /// A reference that identifies the specific occurrence of the error
    /// </summary>
    public string? Instance
    {
        get => Payload.GetDataEntry<string?>(Keys.Instance);
        set => Payload.AddData(Keys.Instance, value!);
    }

    /// <summary>
    /// Whether or not to use the default error type value
    /// </summary>
    public bool? UseDefaultErrorTypeValue
    {
        get => Payload.GetConfigurationEntry<bool?>(Keys.UseDefaultErrorType);
        set => Payload.AddConfiguration(Keys.UseDefaultErrorType, value!);
    }
}
