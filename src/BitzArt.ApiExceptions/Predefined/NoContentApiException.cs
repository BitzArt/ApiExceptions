namespace BitzArt.ApiExceptions;

public class NoContentApiException : ApiExceptionBase
{
    public NoContentApiException(string message = "No Content", IDictionary<string, object>? extensions = null)
        : base(message, ApiStatusCode.NoContent, extensions)
    { }
}
