using System;
using System.Collections.Generic;
using BitzArt.ApiExceptions.Enum;

namespace BitzArt.ApiExceptions
{
    public abstract class ApiExceptionBase : Exception
    {
        public ApiStatusCode StatusCode { get; set; }

        public bool UseDefaultTypeValue { get; set; }

        public string? Problem { get; set; }

        public string? Detail { get; set; }
        public string? Instance { get; set; }
        public IDictionary<string, object?>? Extensions { get; set; }

        protected ApiExceptionBase(string message, ApiStatusCode statusCode = ApiStatusCode.Error, string? problem = null, string? detail = null, string? instance = null, IDictionary<string, object?>? extensions = null, bool useDefaultTypeValue = false) : base(message)
        {
            Problem = problem;
            StatusCode = statusCode;
            Detail = detail;
            Instance = instance;
            Extensions = extensions;
            UseDefaultTypeValue = useDefaultTypeValue;
        }
    }
}
