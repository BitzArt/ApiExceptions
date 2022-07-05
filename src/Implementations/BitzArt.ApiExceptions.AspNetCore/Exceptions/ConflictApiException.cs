using System.Collections.Generic;
using System.Net;

namespace BitzArt.ApiExceptions
{
    public class ConflictApiException : ApiException
    {
        public ConflictApiException(string? message = null, string? type = null, string? detail = null, string? instance = null, IDictionary<string, object?>? extensions = null)
            : base(HttpStatusCode.Conflict, message ?? "Conflict", type, detail, instance, extensions) { }
    }
}
