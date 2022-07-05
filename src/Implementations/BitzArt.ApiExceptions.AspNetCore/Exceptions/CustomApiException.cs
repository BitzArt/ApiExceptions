using System.Collections.Generic;
using System.Net;

namespace BitzArt.ApiExceptions
{
    public class CustomApiException : ApiException
    {
        public CustomApiException(HttpStatusCode statusCode, string? message = null, string? type = null, string? detail = null, string? instance = null, IDictionary<string, object?>? extensions = null)
            : base(statusCode, message ?? "Unexpected error", type, detail, instance, extensions) { }
    }
}
