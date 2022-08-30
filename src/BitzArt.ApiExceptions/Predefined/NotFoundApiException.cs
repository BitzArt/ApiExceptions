namespace BitzArt.ApiExceptions;

public class NotFoundApiException : ApiExceptionBase
{
    public NotFoundApiException(string message = "Not found", IDictionary<string, object>? extensions = null)
        : base(message, ApiStatusCode.NotFound, extensions)
    { }
}
