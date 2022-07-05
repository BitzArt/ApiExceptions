using System.Collections.Generic;
using System.Net;

namespace BitzArt.ApiExceptions
{
    public class CustomApiException : ApiExceptionBase
    {
        public CustomApiException(string? message, HttpStatusCode statusCode, string? type = null, string? detail = null, string? instance = null, IDictionary<string, object?>? extensions = null, bool useDefaultTypeValue = true)
            : base(message ?? "Unexpected error", statusCode, type, detail, instance, extensions, useDefaultTypeValue) { }
    }
}
