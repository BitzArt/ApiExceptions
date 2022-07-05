using BitzArt.ApiExceptions;
using System.Collections.Generic;
using System.Net;

namespace BitzArt
{
    public static class ApiException
    {
        public static CustomApiException Custom(HttpStatusCode statusCode, string? message = null, string? type = null, string? detail = null, string? instance = null, IDictionary<string, object?>? extensions = null)
            => new(statusCode, message, type, detail, instance, extensions);

        public static BadRequestApiException BadRequest(string? message = null, string? type = null, string? detail = null, string? instance = null, IDictionary<string, object?>? extensions = null)
            => new(message, type, detail, instance, extensions);

        public static ConflictApiException Conflict(string? message = null, string? type = null, string? detail = null, string? instance = null, IDictionary<string, object?>? extensions = null)
            => new(message, type, detail, instance, extensions);

        public static ForbiddenApiException Forbidden(string? message = null, string? type = null, string? detail = null, string? instance = null, IDictionary<string, object?>? extensions = null)
            => new(message, type, detail, instance, extensions);

        public static MethodNotAllowedApiException MethodNotAllowed(string? message = null, string? type = null, string? detail = null, string? instance = null, IDictionary<string, object?>? extensions = null)
            => new(message, type, detail, instance, extensions);

        public static NoContentApiException NoContent(string? message = null, string? type = null, string? detail = null, string? instance = null, IDictionary<string, object?>? extensions = null)
            => new(message, type, detail, instance, extensions);

        public static NotFoundApiException NotFound(string? message = null, string? type = null, string? detail = null, string? instance = null, IDictionary<string, object?>? extensions = null)
            => new(message, type, detail, instance, extensions);

        public static UnauthorizedApiException Unauthorized(string? message = null, string? type = null, string? detail = null, string? instance = null, IDictionary<string, object?>? extensions = null)
            => new(message, type, detail, instance, extensions);
    }
}
