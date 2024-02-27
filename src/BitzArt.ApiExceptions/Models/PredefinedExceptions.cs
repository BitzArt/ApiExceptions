namespace BitzArt.ApiExceptions;

public class CustomApiException : ApiExceptionBase
{
    public CustomApiException(string message, ApiStatusCode statusCode = ApiStatusCode.Error, string? errorType = null, ApiExceptionPayload? payload = null, Exception? innerException = null)
        : this(message, (int)statusCode, errorType, payload, innerException)
    { }

    public CustomApiException(string message, int statusCode, string? errorType = null, ApiExceptionPayload? payload = null, Exception? innerException = null)
        : base(message, statusCode, errorType, payload, innerException)
    { }

}

public class InternalErrorApiException : ApiExceptionBase
{
    public InternalErrorApiException(string message = "Internal error", string? errorType = null, ApiExceptionPayload? payload = null, Exception? innerException = null)
        : base(message, ApiStatusCode.Error, errorType, payload, innerException)
    { }
}

public class BadRequestApiException : ApiExceptionBase
{
    public BadRequestApiException(string message = "Bad request", string? errorType = null, ApiExceptionPayload? payload = null, Exception? innerException = null)
        : base(message, ApiStatusCode.BadRequest, errorType, payload, innerException)
    { }
}

public class ConflictApiException : ApiExceptionBase
{
    public ConflictApiException(string message = "Conflict", string? errorType = null, ApiExceptionPayload? payload = null, Exception? innerException = null)
        : base(message, ApiStatusCode.Conflict, errorType, payload, innerException)
    { }
}

public class ForbiddenApiException : ApiExceptionBase
{
    public ForbiddenApiException(string message = "Forbidden", string? errorType = null, ApiExceptionPayload? payload = null, Exception? innerException = null)
        : base(message, ApiStatusCode.Forbidden, errorType, payload, innerException)
    { }
}

public class MethodNotAllowedApiException : ApiExceptionBase
{
    public MethodNotAllowedApiException(string message = "Method not allowed", string? errorType = null, ApiExceptionPayload? payload = null, Exception? innerException = null)
        : base(message, ApiStatusCode.MethodNotAllowed, errorType, payload, innerException)
    { }
}

public class NoContentApiException : ApiExceptionBase
{
    public NoContentApiException(string message = "No Content", string? errorType = null, ApiExceptionPayload? payload = null, Exception? innerException = null)
        : base(message, ApiStatusCode.NoContent, errorType, payload, innerException)
    { }
}

public class NotFoundApiException : ApiExceptionBase
{
    public NotFoundApiException(string message = "Not found", string? errorType = null, ApiExceptionPayload? payload = null, Exception? innerException = null)
        : base(message, ApiStatusCode.NotFound, errorType, payload, innerException)
    { }
}

public class UnauthorizedApiException : ApiExceptionBase
{
    public UnauthorizedApiException(string message = "Unauthorized", string? errorType = null, ApiExceptionPayload? payload = null, Exception? innerException = null)
        : base(message, ApiStatusCode.Unauthorized, errorType, payload, innerException)
    { }
}