using System.Net;

namespace BitzArt.ApiExceptions.AspNetCore.Sample
{
    public class MyVeryCustomApiException : ApiExceptionBase
    {
        private const HttpStatusCode _statusCode = (HttpStatusCode)418;
        private const string _link = "http://example.com/link-to-error-info";
        private const string _msg = "Error message goes here";

        private static readonly IDictionary<string, object?>? extensions = new Dictionary<string, object?>()
        {
            { "customField", "someValue" }
        };

        public MyVeryCustomApiException(string? details = null) : base(_msg, _statusCode, _link, details, extensions: extensions) { }
    }
}
