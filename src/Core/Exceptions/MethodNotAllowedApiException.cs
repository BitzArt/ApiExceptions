using System.Net;

namespace BitzArt.ApiExceptions
{
    public class MethodNotAllowedApiException : CustomApiException
    {
        public MethodNotAllowedApiException(string message = null) : base(HttpStatusCode.MethodNotAllowed, message ?? "Method not allowed") { }
    }
}
