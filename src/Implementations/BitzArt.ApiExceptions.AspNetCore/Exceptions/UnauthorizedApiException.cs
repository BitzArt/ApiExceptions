using System.Collections.Generic;
using System.Net;

namespace BitzArt.ApiExceptions
{
    public class UnauthorizedApiException : CustomApiException
    {
        public UnauthorizedApiException(string? message = null, string? type = null, string? detail = null, string? instance = null, IDictionary<string, object?>? extensions = null)
            : base(HttpStatusCode.Unauthorized, message ?? "Unauthorized", type, detail, instance, extensions) { }
    }
}
