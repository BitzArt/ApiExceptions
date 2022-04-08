using System.Net;

namespace BitzArt.ApiExceptions
{
    public class ForbiddenApiException : CustomApiException
    {
        public ForbiddenApiException(string message = null) : base(HttpStatusCode.Forbidden, message ?? "Forbidden") { }
    }
}
