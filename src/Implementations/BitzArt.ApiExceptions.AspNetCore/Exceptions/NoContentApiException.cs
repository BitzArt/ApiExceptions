using System.Collections.Generic;
using System.Net;

namespace BitzArt.ApiExceptions
{
    public class NoContentApiException : ApiException
    {
        public NoContentApiException(string? message = null, string? type = null, string? detail = null, string? instance = null, IDictionary<string, object?>? extensions = null)
            : base(HttpStatusCode.NoContent, message ?? "No Content", type, detail, instance, extensions) { }
    }
}
