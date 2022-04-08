using System.Net;

namespace BitzArt.ApiExceptions
{
    public class NoContentApiException : CustomApiException
    {
        public NoContentApiException(string message = null) : base(HttpStatusCode.NoContent, message ?? "No Content") { }
    }
}
