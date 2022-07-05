using System.Collections.Generic;
using System.Net;

namespace BitzArt.ApiExceptions
{
    public class UnauthorizedApiException : ApiExceptionBase
    {
        public UnauthorizedApiException(string? message = null, string? type = null, string? detail = null, string? instance = null, IDictionary<string, object?>? extensions = null)
            : base(message ?? "Unauthorized", HttpStatusCode.Unauthorized, type, detail, instance, extensions, true) { }
    }
}
