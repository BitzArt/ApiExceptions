using System.Collections.Generic;
using System.Net;

namespace BitzArt.ApiExceptions
{
    public class NotFoundApiException : ApiExceptionBase
    {
        public NotFoundApiException(string? message = null, string? type = null, string? detail = null, string? instance = null, IDictionary<string, object?>? extensions = null, bool useDefaultTypeValue = true)
            : base(message ?? "Not found", HttpStatusCode.NotFound, type, detail, instance, extensions, useDefaultTypeValue) { }
    }
}
