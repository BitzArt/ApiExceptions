using System;
using System.Net;

namespace BitzArt.ApiExceptions
{
    public class ApiExceptionBase : Exception
    {
        public HttpStatusCode StatusCode { get; private set; }

        protected ApiExceptionBase(HttpStatusCode statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
