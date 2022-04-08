using System;
using System.Net;

namespace BitzArt.ApiExceptions
{
    public class ApiExceptionBase : Exception
    {
        protected HttpStatusCode StatusCode { get; set; }

        protected ApiExceptionBase(HttpStatusCode statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
