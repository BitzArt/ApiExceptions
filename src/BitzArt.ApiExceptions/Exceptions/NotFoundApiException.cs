using BitzArt.ApiExceptions.Enum;
using System.Collections.Generic;

namespace BitzArt.ApiExceptions
{
    public class NotFoundApiException : ApiExceptionBase
    {
        public NotFoundApiException(string? message = null, string? type = null, string? detail = null, string? instance = null, IDictionary<string, object?>? extensions = null, bool useDefaultTypeValue = true)
            : base(message ?? "Not found", ApiStatusCode.NotFound, type, detail, instance, extensions, useDefaultTypeValue) { }
    }
}
