namespace BitzArt.ApiExceptions;

public class MethodNotAllowedApiException : ApiExceptionBase
{
    public MethodNotAllowedApiException(string message = "Method not allowed", IDictionary<string, object>? extensions = null)
        : base(message, ApiStatusCode.MethodNotAllowed, extensions)
    { }
}
