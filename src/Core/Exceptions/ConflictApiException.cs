using System.Net;

namespace BitzArt.ApiExceptions
{
    public class ConflictApiException : CustomApiException
    {
        public ConflictApiException(string message = null) : base(HttpStatusCode.Conflict, message ?? "Conflict") { }
    }
}
