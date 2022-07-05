using System.Collections.Generic;
using System.Net;

namespace BitzArt.ApiExceptions
{
    public class MethodNotAllowedApiException : ApiException
    {
        public MethodNotAllowedApiException(string? message = null, string? type = null, string? detail = null, string? instance = null, IDictionary<string, object?>? extensions = null)
            : base(HttpStatusCode.MethodNotAllowed, message ?? "Method not allowed", type, detail, instance, extensions) { }
    }
}
