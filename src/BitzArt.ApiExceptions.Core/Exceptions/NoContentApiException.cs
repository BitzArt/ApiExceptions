using System.Collections.Generic;
using System.Net;
using BitzArt.ApiExceptions.Enum;

namespace BitzArt.ApiExceptions
{
    public class NoContentApiException : ApiExceptionBase
    {
        public NoContentApiException(string? message = null, string? type = null, string? detail = null, string? instance = null, IDictionary<string, object?>? extensions = null, bool useDefaultTypeValue = true)
            : base(message ?? "No Content", ApiStatusCode.NoContent, type, detail, instance, extensions, useDefaultTypeValue) { }
    }
}
