using BitzArt.ApiExceptions.Enum;
using System.Collections.Generic;

namespace BitzArt.ApiExceptions
{
    public class MethodNotAllowedApiException : ApiExceptionBase
    {
        public MethodNotAllowedApiException(string? message = null, string? type = null, string? detail = null, string? instance = null, IDictionary<string, object?>? extensions = null, bool useDefaultTypeValue = true)
            : base(message ?? "Method not allowed", ApiStatusCode.MethodNotAllowed, type, detail, instance, extensions, useDefaultTypeValue) { }
    }
}
