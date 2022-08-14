using BitzArt.ApiExceptions;
using BitzArt.ApiExceptions.Enum;
using System.Collections.Generic;
using System.Net;

namespace BitzArt
{
    public static class ApiException
    {
        public static CustomApiException Custom(string message, ApiStatusCode statusCode, string? type = null, string? detail = null, string? instance = null, IDictionary<string, object?>? extensions = null)
            => new(message, statusCode, type, detail, instance, extensions);

        public static CustomApiException Custom(string message, int statusCode, string? type = null, string? detail = null, string? instance = null, IDictionary<string, object?>? extensions = null)
            => new(message, statusCode, type, detail, instance, extensions);

        public static BadRequestApiException BadRequest(string message, string? type = null, string? detail = null, string? instance = null, IDictionary<string, object?>? extensions = null)
            => new(message, type, detail, instance, extensions);

        public static ConflictApiException Conflict(string message, string? type = null, string? detail = null, string? instance = null, IDictionary<string, object?>? extensions = null)
            => new(message, type, detail, instance, extensions);

        public static ForbiddenApiException Forbidden(string message, string? type = null, string? detail = null, string? instance = null, IDictionary<string, object?>? extensions = null)
            => new(message, type, detail, instance, extensions);

        public static MethodNotAllowedApiException MethodNotAllowed(string message, string? type = null, string? detail = null, string? instance = null, IDictionary<string, object?>? extensions = null)
            => new(message, type, detail, instance, extensions);

        public static NoContentApiException NoContent(string message, string? type = null, string? detail = null, string? instance = null, IDictionary<string, object?>? extensions = null)
            => new(message, type, detail, instance, extensions);

        public static NotFoundApiException NotFound(string message, string? type = null, string? detail = null, string? instance = null, IDictionary<string, object?>? extensions = null)
            => new(message, type, detail, instance, extensions);

        public static UnauthorizedApiException Unauthorized(string message, string? type = null, string? detail = null, string? instance = null, IDictionary<string, object?>? extensions = null)
            => new(message, type, detail, instance, extensions);
    }
}
