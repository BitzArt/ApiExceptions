namespace BitzArt.ApiExceptions;

public class ForbiddenApiException : ApiExceptionBase
{
    public ForbiddenApiException(string message = "Forbidden", IDictionary<string, object>? extensions = null)
        : base(message, ApiStatusCode.Forbidden, extensions)
    { }
}
