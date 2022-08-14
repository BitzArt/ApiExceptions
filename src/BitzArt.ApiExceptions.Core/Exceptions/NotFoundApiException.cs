using System.Collections.Generic;
using System.Net;
using BitzArt.ApiExceptions.Enum;

namespace BitzArt.ApiExceptions
{
    public class NotFoundApiException : ApiExceptionBase
    {
        public NotFoundApiException(string? message = null, string? type = null, string? detail = null, string? instance = null, IDictionary<string, object?>? extensions = null, bool useDefaultTypeValue = true)
            : base(message ?? "Not found", ApiStatusCode.NotFound, type, detail, instance, extensions, useDefaultTypeValue) { }
    }
}
