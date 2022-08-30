using BitzArt.ApiExceptions;

namespace BitzArt
{
    public static partial class ApiException
    {
        public static CustomApiException Custom
            (string message, ApiStatusCode statusCode = ApiStatusCode.Error, IDictionary<string, object>? extensions = null)
            => new(message, statusCode, extensions);

        public static CustomApiException Custom
            (string message, int statusCode, IDictionary<string, object>? extensions = null)
            => new(message, statusCode, extensions);

        public static BadRequestApiException BadRequest
            (string message, IDictionary<string, object>? extensions = null)
            => new(message, extensions);

        public static ConflictApiException Conflict
            (string message, IDictionary<string, object>? extensions = null)
            => new(message, extensions);

        public static ForbiddenApiException Forbidden
            (string message, IDictionary<string, object>? extensions = null)
            => new(message, extensions);

        public static MethodNotAllowedApiException MethodNotAllowed
            (string message, IDictionary<string, object>? extensions = null)
            => new(message, extensions);

        public static NoContentApiException NoContent
            (string message, IDictionary<string, object>? extensions = null)
            => new(message, extensions);

        public static NotFoundApiException NotFound
            (string message, IDictionary<string, object>? extensions = null)
            => new(message, extensions);

        public static UnauthorizedApiException Unauthorized
            (string message, IDictionary<string, object>? extensions = null)
            => new(message, extensions);
    }
}
