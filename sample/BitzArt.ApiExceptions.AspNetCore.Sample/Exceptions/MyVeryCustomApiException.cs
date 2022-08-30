namespace BitzArt.ApiExceptions.AspNetCore.Sample
{
    public class MyVeryCustomApiException : ApiExceptionBase
    {
        private const int _statusCode = 418;
        private const string _errorType = "http://example.com/link-to-error-info";
        private const string _msg = "Error message goes here";

        private static readonly object _extensions = new
        {
            type = _errorType,
            customField = "someValue"
        };

        public MyVeryCustomApiException(string? detail = null) : base(_msg, _statusCode)
        {
            if (detail is not null) this.AddDetail(detail);
            AddExtensions(_extensions);
        }
    }
}
