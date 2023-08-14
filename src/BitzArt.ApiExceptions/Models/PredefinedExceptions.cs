namespace BitzArt.ApiExceptions;

public class CustomApiException : ApiExceptionBase
{
    public CustomApiException(string message, ApiStatusCode statusCode = ApiStatusCode.Error, ApiExceptionPayload? payload = null, Exception? innerException = null)
        : this(message, (int)statusCode, payload, innerException)
    { }

    public CustomApiException(string message, int statusCode, ApiExceptionPayload? payload = null, Exception? innerException = null)
        : base(message, statusCode, payload, innerException)
    { }

}

public class InternalErrorApiException : ApiExceptionBase
{
    public InternalErrorApiException(string message = "Internal error", ApiExceptionPayload? payload = null, Exception? innerException = null)
        : base(message, ApiStatusCode.Error, payload, innerException)
    { }
}

public class BadRequestApiException : ApiExceptionBase
{
    public BadRequestApiException(string message = "Bad request", ApiExceptionPayload? payload = null, Exception? innerException = null)
        : base(message, ApiStatusCode.BadRequest, payload, innerException)
    { }
}

public class ConflictApiException : ApiExceptionBase
{
    public ConflictApiException(string message = "Conflict", ApiExceptionPayload? payload = null, Exception? innerException = null)
        : base(message, ApiStatusCode.Conflict, payload, innerException)
    { }
}

public class ForbiddenApiException : ApiExceptionBase
{
    public ForbiddenApiException(string message = "Forbidden", ApiExceptionPayload? payload = null, Exception? innerException = null)
        : base(message, ApiStatusCode.Forbidden, payload, innerException)
    { }
}

public class MethodNotAllowedApiException : ApiExceptionBase
{
    public MethodNotAllowedApiException(string message = "Method not allowed", ApiExceptionPayload? payload = null, Exception? innerException = null)
        : base(message, ApiStatusCode.MethodNotAllowed, payload, innerException)
    { }
}

public class NoContentApiException : ApiExceptionBase
{
    public NoContentApiException(string message = "No Content", ApiExceptionPayload? payload = null, Exception? innerException = null)
        : base(message, ApiStatusCode.NoContent, payload, innerException)
    { }
}

public class NotFoundApiException : ApiExceptionBase
{
    public NotFoundApiException(string message = "Not found", ApiExceptionPayload? payload = null, Exception? innerException = null)
        : base(message, ApiStatusCode.NotFound, payload, innerException)
    { }
}

public class UnauthorizedApiException : ApiExceptionBase
{
    public UnauthorizedApiException(string message = "Unauthorized", ApiExceptionPayload? payload = null, Exception? innerException = null)
        : base(message, ApiStatusCode.Unauthorized, payload, innerException)
    { }
}