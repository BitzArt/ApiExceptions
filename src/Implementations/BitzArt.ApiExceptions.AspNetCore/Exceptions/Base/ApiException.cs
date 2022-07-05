using System;
using System.Collections.Generic;
using System.Net;

namespace BitzArt.ApiExceptions
{
    public abstract class ApiException : Exception
    {
        public int StatusCode { get; set; }

        public string? Type { get; set; }
        public string? Detail { get; set; }
        public string? Instance { get; set; }
        public IDictionary<string, object?>? Extensions { get; }

        protected ApiException(HttpStatusCode statusCode, string message, string? type = null, string? detail = null, string? instance = null, IDictionary<string, object?>? extensions = null) : base(message)
        {
            Type = type;
            StatusCode = (int)statusCode;
            Detail = detail;
            Instance = instance;
            Extensions = extensions;
        }
    }
}
