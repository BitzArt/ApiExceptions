namespace BitzArt.ApiExceptions;

public class CustomApiException : ApiExceptionBase
{
    public CustomApiException(string message, ApiStatusCode statusCode = ApiStatusCode.Error, IDictionary<string, object>? extensions = null)
        : this(message, (int)statusCode, extensions)
    { }

    public CustomApiException(string message, int statusCode, IDictionary<string, object>? extensions = null)
        : base(message, statusCode, extensions)
    { }

}
