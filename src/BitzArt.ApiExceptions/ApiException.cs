using BitzArt.ApiExceptions;

namespace BitzArt;

public partial class ApiException
{
    /// <summary>
    /// Creates a new instance of <see cref="CustomApiException"/>
    /// </summary>
    /// <param name="message"></param>
    /// <param name="statusCode"></param>
    /// <param name="errorType"></param>
    /// <param name="payload"></param>
    /// <param name="innerException"></param>
    /// <returns></returns>
    public static ApiException Custom
        (string message, ApiStatusCode statusCode = ApiStatusCode.Error, string? errorType = null, ApiExceptionPayload? payload = null, Exception? innerException = null)
        => new(message, statusCode, errorType, payload, innerException);

    /// <summary>
    /// Creates a new instance of <see cref="CustomApiException"/>
    /// </summary>
    /// <param name="message"></param>
    /// <param name="statusCode"></param>
    /// <param name="errorType"></param>
    /// <param name="payload"></param>
    /// <param name="innerException"></param>
    /// <returns></returns>
    public static ApiException Custom
        (string message, int statusCode, string? errorType = null, ApiExceptionPayload? payload = null, Exception? innerException = null)
        => new(message, statusCode, errorType, payload, innerException);

    /// <summary>
    /// Creates a new instance of <see cref="InternalErrorApiException"/>
    /// </summary>
    /// <param name="message"></param>
    /// <param name="errorType"></param>
    /// <param name="payload"></param>
    /// <param name="innerException"></param>
    /// <returns></returns>
    public static InternalErrorApiException InternalError
        (string message, string? errorType = null, ApiExceptionPayload? payload = null, Exception? innerException = null)
        => new(message, errorType, payload, innerException);

    /// <summary>
    /// Creates a new instance of <see cref="BadRequestApiException"/>
    /// </summary>
    /// <param name="message"></param>
    /// <param name="errorType"></param>
    /// <param name="payload"></param>
    /// <param name="innerException"></param>
    /// <returns></returns>
    public static BadRequestApiException BadRequest
        (string message, string? errorType = null, ApiExceptionPayload? payload = null, Exception? innerException = null)
        => new(message, errorType, payload, innerException);

    /// <summary>
    /// Creates a new instance of <see cref="ConflictApiException"/>
    /// </summary>
    /// <param name="message"></param>
    /// <param name="errorType"></param>
    /// <param name="payload"></param>
    /// <param name="innerException"></param>
    /// <returns></returns>
    public static ConflictApiException Conflict
        (string message, string? errorType = null, ApiExceptionPayload? payload = null, Exception? innerException = null)
        => new(message, errorType, payload, innerException);

    /// <summary>
    /// Creates a new instance of <see cref="ForbiddenApiException"/>
    /// </summary>
    /// <param name="message"></param>
    /// <param name="errorType"></param>
    /// <param name="payload"></param>
    /// <param name="innerException"></param>
    /// <returns></returns>
    public static ForbiddenApiException Forbidden
        (string message, string? errorType = null, ApiExceptionPayload? payload = null, Exception? innerException = null)
        => new(message, errorType, payload, innerException);

    /// <summary>
    /// Creates a new instance of <see cref="MethodNotAllowed"/>
    /// </summary>
    /// <param name="message"></param>
    /// <param name="errorType"></param>
    /// <param name="payload"></param>
    /// <param name="innerException"></param>
    /// <returns></returns>
    public static MethodNotAllowedApiException MethodNotAllowed
        (string message, string? errorType = null, ApiExceptionPayload? payload = null, Exception? innerException = null)
        => new(message, errorType, payload, innerException);

    /// <summary>
    /// Creates a new instance of <see cref="NoContentApiException"/>
    /// </summary>
    /// <param name="message"></param>
    /// <param name="errorType"></param>
    /// <param name="payload"></param>
    /// <param name="innerException"></param>
    /// <returns></returns>
    public static NoContentApiException NoContent
        (string message, string? errorType = null, ApiExceptionPayload? payload = null, Exception? innerException = null)
        => new(message, errorType, payload, innerException);

    /// <summary>
    /// Creates a new instance of <see cref="NotFoundApiException"/>
    /// </summary>
    /// <param name="message"></param>
    /// <param name="errorType"></param>
    /// <param name="payload"></param>
    /// <param name="innerException"></param>
    /// <returns></returns>
    public static NotFoundApiException NotFound
        (string message, string? errorType = null, ApiExceptionPayload? payload = null, Exception? innerException = null)
        => new(message, errorType, payload, innerException);

    /// <summary>
    /// Creates a new instance of <see cref="UnauthorizedApiException"/>
    /// </summary>
    /// <param name="message"></param>
    /// <param name="errorType"></param>
    /// <param name="payload"></param>
    /// <param name="innerException"></param>
    /// <returns></returns>
    public static UnauthorizedApiException Unauthorized
        (string message, string? errorType = null, ApiExceptionPayload? payload = null, Exception? innerException = null)
        => new(message, errorType, payload, innerException);
}
