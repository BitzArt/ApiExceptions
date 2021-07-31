using System.Net;

namespace BitzArt.ApiExceptions
{
    public class NoContentException : ApiException
    {
        public NoContentException(string message) : base(HttpStatusCode.NoContent, message) { }
    }
}
