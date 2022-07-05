using System.Collections.Generic;
using System.Net;

namespace BitzArt.ApiExceptions
{
    public class BadRequestApiException : ApiException
    {
        public BadRequestApiException(string? message = null, string? type = null, string? detail = null, string? instance = null, IDictionary<string, object?>? extensions = null)
            : base(HttpStatusCode.BadRequest, message ?? "Bad request", type, detail, instance, extensions) { }
    }
}
