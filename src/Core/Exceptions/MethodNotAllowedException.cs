using System.Net;

namespace BitzArt.ApiExceptions
{
    public class MethodNotAllowedException : ApiException
    {
        public MethodNotAllowedException(string message) : base(HttpStatusCode.MethodNotAllowed, message) { }
    }
}
