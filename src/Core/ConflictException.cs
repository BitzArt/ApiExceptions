using System.Net;

namespace BitzArt.ApiExceptions
{
    public class ConflictException : ApiException
    {
        public ConflictException(string message) : base(HttpStatusCode.Conflict, message) { }
    }
}
