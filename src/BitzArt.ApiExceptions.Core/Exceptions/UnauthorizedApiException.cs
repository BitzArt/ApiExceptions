using System.Collections.Generic;
using System.Net;
using BitzArt.ApiExceptions.Enum;

namespace BitzArt.ApiExceptions
{
    public class UnauthorizedApiException : ApiExceptionBase
    {
        public UnauthorizedApiException(string? message = null, string? type = null, string? detail = null, string? instance = null, IDictionary<string, object?>? extensions = null, bool useDefaultTypeValue = true)
            : base(message ?? "Unauthorized", ApiStatusCode.Unauthorized, type, detail, instance, extensions, useDefaultTypeValue) { }
    }
}
