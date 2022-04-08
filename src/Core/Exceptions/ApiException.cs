using System;
using System.Net;

namespace BitzArt.ApiExceptions
{
    public class ApiException : ApiExceptionBase
    {
        public ApiException(HttpStatusCode statusCode, string message) : base(statusCode, message) { }
    }
}
