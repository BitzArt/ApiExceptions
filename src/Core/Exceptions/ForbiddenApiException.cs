using System.Net;

namespace BitzArt.ApiExceptions
{
    public class ForbiddenApiException : ApiException
    {
        public ForbiddenApiException(string message) : base(HttpStatusCode.Forbidden, message) { }
    }
}
