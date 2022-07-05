using System.Collections.Generic;
using System.Net;

namespace BitzArt.ApiExceptions
{
    public class ForbiddenApiException : ApiExceptionBase
    {
        public ForbiddenApiException(string? message = null, string? type = null, string? detail = null, string? instance = null, IDictionary<string, object?>? extensions = null)
            : base(message ?? "Forbidden", HttpStatusCode.Forbidden, type, detail, instance, extensions, true) { }
    }
}
