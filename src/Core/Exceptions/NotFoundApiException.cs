using System.Net;

namespace BitzArt.ApiExceptions
{
    public class NotFoundApiException : CustomApiException
    {
        public NotFoundApiException(string message = null) : base(HttpStatusCode.NotFound, message ?? "Not found") { }
    }
}
