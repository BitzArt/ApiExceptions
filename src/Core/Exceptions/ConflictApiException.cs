using System.Net;

namespace BitzArt.ApiExceptions
{
    public class ConflictApiException : ApiException
    {
        public ConflictApiException(string message) : base(HttpStatusCode.Conflict, message) { }
    }
}
