using BitzArt.ApiExceptions;
using System.Net;

namespace BitzArt
{
    public static class ApiException
    {
        public static CustomApiException Custom(HttpStatusCode statusCode, string message = null) => new CustomApiException(statusCode, message);

        public static BadRequestApiException BadRequest(string message = null) => new BadRequestApiException(message);
        public static ConflictApiException Conflict(string message = null) => new ConflictApiException(message);
        public static ForbiddenApiException Forbidden(string message = null) => new ForbiddenApiException(message);
        public static MethodNotAllowedApiException MethodNotAllowed(string message = null) => new MethodNotAllowedApiException(message);
        public static NoContentApiException NoContent(string message = null) => new NoContentApiException(message);
        public static NotFoundApiException NotFound(string message = null) => new NotFoundApiException(message);
        public static UnauthorizedApiException Unauthorized(string message = null) => new UnauthorizedApiException(message);
    }
}
