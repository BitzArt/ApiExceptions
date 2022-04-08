using System.Net;

namespace BitzArt.ApiExceptions
{
    public class BadRequestApiException : ApiException
    {
        public BadRequestApiException(string message) : base(HttpStatusCode.BadRequest, message) { }
    }
}
