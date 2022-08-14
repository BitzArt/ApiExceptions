using System.Collections.Generic;

namespace BitzArt.ApiExceptions
{
    public class CustomApiException : ApiExceptionBase
    {
        private const string DefaultMessage = "Unexpected error";

        public CustomApiException(string? message, ApiStatusCode statusCode, string? type = null, string? detail = null, string? instance = null, IDictionary<string, object?>? extensions = null, bool useDefaultTypeValue = true)
            : base(message ?? DefaultMessage, statusCode, type, detail, instance, extensions, useDefaultTypeValue) { }

        public CustomApiException(string? message, int statusCode, string? type = null, string? detail = null, string? instance = null, IDictionary<string, object?>? extensions = null, bool useDefaultTypeValue = true)
            : base(message ?? DefaultMessage, (ApiStatusCode)statusCode, type, detail, instance, extensions, useDefaultTypeValue) { }

    }
}
