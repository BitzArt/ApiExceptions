using System.Collections.Generic;
using System.Net;

namespace BitzArt.ApiExceptions
{
    public class MethodNotAllowedApiException : ApiExceptionBase
    {
        public MethodNotAllowedApiException(string? message = null, string? type = null, string? detail = null, string? instance = null, IDictionary<string, object?>? extensions = null)
            : base(message ?? "Method not allowed", HttpStatusCode.MethodNotAllowed, type, detail, instance, extensions, true) { }
    }
}
