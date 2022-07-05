using System.Net;

namespace BitzArt.ApiExceptions
{
    public class CustomApiException : ApiExceptionBase
    {
        public CustomApiException(HttpStatusCode statusCode, string message = null) : base(statusCode, message ?? "Unexpected error") { }
    }
}
