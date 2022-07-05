using System.Collections.Generic;
using System.Net;

namespace BitzArt.ApiExceptions
{
    public class ConflictApiException : ApiExceptionBase
    {
        public ConflictApiException(string? message = null, string? type = null, string? detail = null, string? instance = null, IDictionary<string, object?>? extensions = null)
            : base(message ?? "Conflict", HttpStatusCode.Conflict, type, detail, instance, extensions, true) { }
    }
}
