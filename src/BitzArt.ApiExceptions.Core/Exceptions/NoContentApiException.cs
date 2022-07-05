using System.Collections.Generic;
using System.Net;

namespace BitzArt.ApiExceptions
{
    public class NoContentApiException : ApiExceptionBase
    {
        public NoContentApiException(string? message = null, string? type = null, string? detail = null, string? instance = null, IDictionary<string, object?>? extensions = null)
            : base(message ?? "No Content", HttpStatusCode.NoContent, type, detail, instance, extensions, true) { }
    }
}
