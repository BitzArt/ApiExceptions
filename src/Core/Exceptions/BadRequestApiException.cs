using System.Net;

namespace BitzArt.ApiExceptions
{
    public class BadRequestApiException : CustomApiException
    {
        public BadRequestApiException(string message = null) : base(HttpStatusCode.BadRequest, message ?? "Bad request") { }
    }
}
