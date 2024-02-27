using BitzArt.ApiExceptions;

namespace BitzArt;

public static partial class ApiException
{
    public static CustomApiException Custom
        (string message, ApiStatusCode statusCode = ApiStatusCode.Error, string? errorType = null, ApiExceptionPayload? payload = null, Exception? innerException = null)
        => new(message, statusCode, errorType, payload, innerException);

    public static CustomApiException Custom
        (string message, int statusCode, string? errorType = null, ApiExceptionPayload? payload = null, Exception? innerException = null)
        => new(message, statusCode, errorType, payload, innerException);

    public static InternalErrorApiException InternalError
        (string message, string? errorType = null, ApiExceptionPayload? payload = null, Exception? innerException = null)
        => new(message, errorType, payload, innerException);

    public static BadRequestApiException BadRequest
        (string message, string? errorType = null, ApiExceptionPayload? payload = null, Exception? innerException = null)
        => new(message, errorType, payload, innerException);

    public static ConflictApiException Conflict
        (string message, string? errorType = null, ApiExceptionPayload? payload = null, Exception? innerException = null)
        => new(message, errorType, payload, innerException);

    public static ForbiddenApiException Forbidden
        (string message, string? errorType = null, ApiExceptionPayload? payload = null, Exception? innerException = null)
        => new(message, errorType, payload, innerException);

    public static MethodNotAllowedApiException MethodNotAllowed
        (string message, string? errorType = null, ApiExceptionPayload? payload = null, Exception? innerException = null)
        => new(message, errorType, payload, innerException);

    public static NoContentApiException NoContent
        (string message, string? errorType = null, ApiExceptionPayload? payload = null, Exception? innerException = null)
        => new(message, errorType, payload, innerException);

    public static NotFoundApiException NotFound
        (string message, string? errorType = null, ApiExceptionPayload? payload = null, Exception? innerException = null)
        => new(message, errorType, payload, innerException);

    public static UnauthorizedApiException Unauthorized
        (string message, string? errorType = null, ApiExceptionPayload? payload = null, Exception? innerException = null)
        => new(message, errorType, payload, innerException);
}
