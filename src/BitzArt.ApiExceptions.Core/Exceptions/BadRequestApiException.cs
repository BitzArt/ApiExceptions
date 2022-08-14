using System.Collections.Generic;
using System.Net;
using BitzArt.ApiExceptions.Enum;

namespace BitzArt.ApiExceptions
{
    public class BadRequestApiException : ApiExceptionBase
    {
        public BadRequestApiException(string? message = null, string? type = null, string? detail = null, string? instance = null, IDictionary<string, object?>? extensions = null, bool useDefaultTypeValue = true)
            : base(message ?? "Bad request", ApiStatusCode.BadRequest, type, detail, instance, extensions, useDefaultTypeValue) { }
    }
}
