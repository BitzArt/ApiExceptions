using System;
using System.Net;

namespace BitzArt.ApiExceptions
{
    public class ApiExceptionBase : Exception
    {
        public HttpStatusCode StatusCode { get; private set; }

        public string Type { get; private set; }

        public string Detail { get; private set; }

        protected ApiExceptionBase(
            HttpStatusCode statusCode,
            string message
            ) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
