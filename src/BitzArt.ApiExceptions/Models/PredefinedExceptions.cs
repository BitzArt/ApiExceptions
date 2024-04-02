namespace BitzArt.ApiExceptions;

/// <summary>
/// Represents a custom API exception.
/// </summary>
public class CustomApiException : ApiExceptionBase
{
    /// <summary>
    /// Creates a new <see cref="CustomApiException"/>
    /// </summary>
    public CustomApiException(string message, ApiStatusCode statusCode = ApiStatusCode.Error, string? errorType = null, ApiExceptionPayload? payload = null, Exception? innerException = null)
        : this(message, (int)statusCode, errorType, payload, innerException)
    { }

    /// <summary>
    /// Creates a new <see cref="CustomApiException"/>
    /// </summary>
    /// <param name="message"></param>
    /// <param name="statusCode"></param>
    /// <param name="errorType"></param>
    /// <param name="payload"></param>
    /// <param name="innerException"></param>
    public CustomApiException(string message, int statusCode, string? errorType = null, ApiExceptionPayload? payload = null, Exception? innerException = null)
        : base(message, statusCode, errorType, payload, innerException)
    { }

}

/// <summary>
/// Represents an internal error API exception.
/// </summary>
public class InternalErrorApiException : ApiExceptionBase
{
    /// <summary>
    /// Creates a new <see cref="InternalErrorApiException"/>
    /// </summary>
    /// <param name="message"></param>
    /// <param name="errorType"></param>
    /// <param name="payload"></param>
    /// <param name="innerException"></param>
    public InternalErrorApiException(string message = "Internal error", string? errorType = null, ApiExceptionPayload? payload = null, Exception? innerException = null)
        : base(message, ApiStatusCode.Error, errorType, payload, innerException)
    { }
}

/// <summary>
/// Represents a bad request API exception.
/// </summary>
public class BadRequestApiException : ApiExceptionBase
{
    /// <summary>
    /// Creates a new <see cref="BadRequestApiException"/>
    /// </summary>
    /// <param name="message"></param>
    /// <param name="errorType"></param>
    /// <param name="payload"></param>
    /// <param name="innerException"></param>
    public BadRequestApiException(string message = "Bad request", string? errorType = null, ApiExceptionPayload? payload = null, Exception? innerException = null)
        : base(message, ApiStatusCode.BadRequest, errorType, payload, innerException)
    { }
}

/// <summary>
/// Represents a conflict API exception.
/// </summary>
public class ConflictApiException : ApiExceptionBase
{
    /// <summary>
    /// Creates a new <see cref="ConflictApiException"/>
    /// </summary>
    /// <param name="message"></param>
    /// <param name="errorType"></param>
    /// <param name="payload"></param>
    /// <param name="innerException"></param>
    public ConflictApiException(string message = "Conflict", string? errorType = null, ApiExceptionPayload? payload = null, Exception? innerException = null)
        : base(message, ApiStatusCode.Conflict, errorType, payload, innerException)
    { }
}

/// <summary>
/// Represents a forbidden API exception.
/// </summary>
public class ForbiddenApiException : ApiExceptionBase
{
    /// <summary>
    /// Creates a new <see cref="ForbiddenApiException"/>
    /// </summary>
    /// <param name="message"></param>
    /// <param name="errorType"></param>
    /// <param name="payload"></param>
    /// <param name="innerException"></param>
    public ForbiddenApiException(string message = "Forbidden", string? errorType = null, ApiExceptionPayload? payload = null, Exception? innerException = null)
        : base(message, ApiStatusCode.Forbidden, errorType, payload, innerException)
    { }
}

/// <summary>
/// Represents a method not allowed API exception.
/// </summary>
public class MethodNotAllowedApiException : ApiExceptionBase
{
    /// <summary>
    /// Creates a new <see cref="MethodNotAllowedApiException"/>
    /// </summary>
    /// <param name="message"></param>
    /// <param name="errorType"></param>
    /// <param name="payload"></param>
    /// <param name="innerException"></param>
    public MethodNotAllowedApiException(string message = "Method not allowed", string? errorType = null, ApiExceptionPayload? payload = null, Exception? innerException = null)
        : base(message, ApiStatusCode.MethodNotAllowed, errorType, payload, innerException)
    { }
}

/// <summary>
/// Represents a no content API exception.
/// </summary>
public class NoContentApiException : ApiExceptionBase
{
    /// <summary>
    /// Creates a new <see cref="NoContentApiException"/>
    /// </summary>
    /// <param name="message"></param>
    /// <param name="errorType"></param>
    /// <param name="payload"></param>
    /// <param name="innerException"></param>
    public NoContentApiException(string message = "No Content", string? errorType = null, ApiExceptionPayload? payload = null, Exception? innerException = null)
        : base(message, ApiStatusCode.NoContent, errorType, payload, innerException)
    { }
}

/// <summary>
/// Represents a not found API exception.
/// </summary>
public class NotFoundApiException : ApiExceptionBase
{
    /// <summary>
    /// Creates a new <see cref="NotFoundApiException"/>
    /// </summary>
    /// <param name="message"></param>
    /// <param name="errorType"></param>
    /// <param name="payload"></param>
    /// <param name="innerException"></param>
    public NotFoundApiException(string message = "Not found", string? errorType = null, ApiExceptionPayload? payload = null, Exception? innerException = null)
        : base(message, ApiStatusCode.NotFound, errorType, payload, innerException)
    { }
}

/// <summary>
/// Represents an unauthorized API exception.
/// </summary>
public class UnauthorizedApiException : ApiExceptionBase
{
    /// <summary>
    /// Creates a new <see cref="UnauthorizedApiException"/>
    /// </summary>
    /// <param name="message"></param>
    /// <param name="errorType"></param>
    /// <param name="payload"></param>
    /// <param name="innerException"></param>
    public UnauthorizedApiException(string message = "Unauthorized", string? errorType = null, ApiExceptionPayload? payload = null, Exception? innerException = null)
        : base(message, ApiStatusCode.Unauthorized, errorType, payload, innerException)
    { }
}