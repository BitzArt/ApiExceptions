using System.Collections.Generic;
using System.Net;

namespace BitzArt.ApiExceptions
{
    public class NotFoundApiException : ApiException
    {
        public NotFoundApiException(string? message = null, string? type = null, string? detail = null, string? instance = null, IDictionary<string, object?>? extensions = null)
            : base(HttpStatusCode.NotFound, message ?? "Not found", type, detail, instance, extensions) { }
    }
}
