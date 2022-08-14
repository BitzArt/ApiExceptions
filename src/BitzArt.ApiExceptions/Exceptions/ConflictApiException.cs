using System.Collections.Generic;
using System.Net;
using BitzArt.ApiExceptions.Enum;

namespace BitzArt.ApiExceptions
{
    public class ConflictApiException : ApiExceptionBase
    {
        public ConflictApiException(string? message = null, string? type = null, string? detail = null, string? instance = null, IDictionary<string, object?>? extensions = null, bool useDefaultTypeValue = true)
            : base(message ?? "Conflict", ApiStatusCode.Conflict, type, detail, instance, extensions, useDefaultTypeValue) { }
    }
}
