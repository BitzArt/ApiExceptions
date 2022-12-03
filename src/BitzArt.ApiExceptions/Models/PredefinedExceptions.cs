namespace BitzArt.ApiExceptions;

public class CustomApiException : ApiExceptionBase
{
    public CustomApiException(string message, ApiStatusCode statusCode = ApiStatusCode.Error, ApiExceptionPayload? payload = null)
        : this(message, (int)statusCode, payload)
    { }

    public CustomApiException(string message, int statusCode, ApiExceptionPayload? payload = null)
        : base(message, statusCode, payload)
    { }

}

public class InternalErrorApiException : ApiExceptionBase
{
    public InternalErrorApiException(string message = "Internal error", ApiExceptionPayload? payload = null)
        : base(message, ApiStatusCode.Error, payload)
    { }
}

public class BadRequestApiException : ApiExceptionBase
{
    public BadRequestApiException(string message = "Bad request", ApiExceptionPayload? payload = null)
        : base(message, ApiStatusCode.BadRequest, payload)
    { }
}

public class ConflictApiException : ApiExceptionBase
{
    public ConflictApiException(string message = "Conflict", ApiExceptionPayload? payload = null)
        : base(message, ApiStatusCode.Conflict, payload)
    { }
}

public class ForbiddenApiException : ApiExceptionBase
{
    public ForbiddenApiException(string message = "Forbidden", ApiExceptionPayload? payload = null)
        : base(message, ApiStatusCode.Forbidden, payload)
    { }
}

public class MethodNotAllowedApiException : ApiExceptionBase
{
    public MethodNotAllowedApiException(string message = "Method not allowed", ApiExceptionPayload? payload = null)
        : base(message, ApiStatusCode.MethodNotAllowed, payload)
    { }
}

public class NoContentApiException : ApiExceptionBase
{
    public NoContentApiException(string message = "No Content", ApiExceptionPayload? payload = null)
        : base(message, ApiStatusCode.NoContent, payload)
    { }
}

public class NotFoundApiException : ApiExceptionBase
{
    public NotFoundApiException(string message = "Not found", ApiExceptionPayload? payload = null)
        : base(message, ApiStatusCode.NotFound, payload)
    { }
}

public class UnauthorizedApiException : ApiExceptionBase
{
    public UnauthorizedApiException(string message = "Unauthorized", ApiExceptionPayload? payload = null)
        : base(message, ApiStatusCode.Unauthorized, payload)
    { }
}