using BitzArt.ApiExceptions;

namespace BitzArt;

public static partial class ApiException
{
    public static CustomApiException Custom
        (string message, ApiStatusCode statusCode = ApiStatusCode.Error, ApiExceptionPayload? payload = null)
        => new(message, statusCode, payload);

    public static CustomApiException Custom
        (string message, int statusCode, ApiExceptionPayload? payload = null)
        => new(message, statusCode, payload);

    public static BadRequestApiException BadRequest
        (string message, ApiExceptionPayload? payload = null)
        => new(message, payload);

    public static ConflictApiException Conflict
        (string message, ApiExceptionPayload? payload = null)
        => new(message, payload);

    public static ForbiddenApiException Forbidden
        (string message, ApiExceptionPayload? payload = null)
        => new(message, payload);

    public static MethodNotAllowedApiException MethodNotAllowed
        (string message, ApiExceptionPayload? payload = null)
        => new(message, payload);

    public static NoContentApiException NoContent
        (string message, ApiExceptionPayload? payload = null)
        => new(message, payload);

    public static NotFoundApiException NotFound
        (string message, ApiExceptionPayload? payload = null)
        => new(message, payload);

    public static UnauthorizedApiException Unauthorized
        (string message, ApiExceptionPayload? payload = null)
        => new(message, payload);
}
