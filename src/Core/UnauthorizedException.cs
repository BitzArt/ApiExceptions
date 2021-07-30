using System.Net;

namespace BitzArt.ApiExceptions
{
    public class UnauthorizedException : ApiException
    {
        public UnauthorizedException(string message) : base(HttpStatusCode.Unauthorized, message) { }
    }
}
