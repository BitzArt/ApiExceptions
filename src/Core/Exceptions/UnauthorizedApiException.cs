using System.Net;

namespace BitzArt.ApiExceptions
{
    public class UnauthorizedApiException : CustomApiException
    {
        public UnauthorizedApiException(string message = null) : base(HttpStatusCode.Unauthorized, message ?? "Unauthorized") { }
    }
}
