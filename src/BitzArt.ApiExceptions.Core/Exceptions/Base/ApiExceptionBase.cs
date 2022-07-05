using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace BitzArt.ApiExceptions
{
    public abstract class ApiExceptionBase : Exception
    {
        public int StatusCode { get; set; }

        public bool UseDefaultTypeValue { get; set; }

        private string? _type;
        public string? Type
        {
            get
            {
                if (_type is not null) return _type;
                if (!UseDefaultTypeValue) return null;
                return $"{Config.DocumentationLink}/{StatusCode}";
            }
            set => _type = value;
        }

        public string? Detail { get; set; }
        public string? Instance { get; set; }
        public IDictionary<string, object?>? Extensions { get; set; }

        protected ApiExceptionBase(string message, HttpStatusCode statusCode = HttpStatusCode.InternalServerError, string? type = null, string? detail = null, string? instance = null, IDictionary<string, object?>? extensions = null, bool useDefaultTypeValue = false) : base(message)
        {
            Type = type;
            StatusCode = (int)statusCode;
            Detail = detail;
            Instance = instance;
            Extensions = extensions;
            UseDefaultTypeValue = useDefaultTypeValue;
        }
    }
}
