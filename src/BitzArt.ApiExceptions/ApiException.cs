using BitzArt.ApiExceptions;

namespace BitzArt;

public static partial class ApiException
{
    public static CustomApiException Custom
        (string message, ApiStatusCode statusCode = ApiStatusCode.Error, ApiExceptionPayload? payload = null, Exception? innerException = null)
        => new(message, statusCode, payload, innerException);

    public static CustomApiException Custom
        (string message, int statusCode, ApiExceptionPayload? payload = null, Exception? innerException = null)
        => new(message, statusCode, payload, innerException);

    public static InternalErrorApiException InternalError
        (string message, ApiExceptionPayload? payload = null, Exception? innerException = null)
        => new(message, payload, innerException);

    public static BadRequestApiException BadRequest
        (string message, ApiExceptionPayload? payload = null, Exception? innerException = null)
        => new(message, payload, innerException);

    public static ConflictApiException Conflict
        (string message, ApiExceptionPayload? payload = null, Exception? innerException = null)
        => new(message, payload, innerException);

    public static ForbiddenApiException Forbidden
        (string message, ApiExceptionPayload? payload = null, Exception? innerException = null)
        => new(message, payload, innerException);

    public static MethodNotAllowedApiException MethodNotAllowed
        (string message, ApiExceptionPayload? payload = null, Exception? innerException = null)
        => new(message, payload, innerException);

    public static NoContentApiException NoContent
        (string message, ApiExceptionPayload? payload = null, Exception? innerException = null)
        => new(message, payload, innerException);

    public static NotFoundApiException NotFound
        (string message, ApiExceptionPayload? payload = null, Exception? innerException = null)
        => new(message, payload, innerException);

    public static UnauthorizedApiException Unauthorized
        (string message, ApiExceptionPayload? payload = null, Exception? innerException = null)
        => new(message, payload, innerException);
}
