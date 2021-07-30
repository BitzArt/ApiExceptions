using System.Net;

namespace BitzArt.ApiExceptions
{
    public class NotFoundException : ApiException
    {
        public NotFoundException(string message) : base(HttpStatusCode.NotFound, message) { }
    }
}
