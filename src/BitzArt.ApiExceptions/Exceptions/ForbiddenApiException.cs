using System.Collections.Generic;

namespace BitzArt.ApiExceptions
{
    public class ForbiddenApiException : ApiExceptionBase
    {
        public ForbiddenApiException(string? message = null, string? type = null, string? detail = null, string? instance = null, IDictionary<string, object?>? extensions = null, bool useDefaultTypeValue = true)
            : base(message ?? "Forbidden", ApiStatusCode.Forbidden, type, detail, instance, extensions, useDefaultTypeValue) { }
    }
}
