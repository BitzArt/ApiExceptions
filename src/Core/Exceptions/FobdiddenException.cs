using System.Net;

namespace BitzArt.ApiExceptions
{
    public class ForbiddenException : ApiException
    {
        public ForbiddenException(string message) : base(HttpStatusCode.Forbidden, message) { }
    }
}
