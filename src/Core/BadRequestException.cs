using System.Net;

namespace BitzArt.ApiExceptions
{
    public class BadRequestException : ApiException
    {
        public BadRequestException(string message) : base(HttpStatusCode.BadRequest, message) { }
    }
}
