namespace BitzArt.ApiExceptions;

public class UnauthorizedApiException : ApiExceptionBase
{
    public UnauthorizedApiException(string message = "Unauthorized", IDictionary<string, object>? extensions = null)
        : base(message, ApiStatusCode.Unauthorized, extensions)
    { }
}
