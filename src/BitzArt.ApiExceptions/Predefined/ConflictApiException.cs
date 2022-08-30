namespace BitzArt.ApiExceptions;

public class ConflictApiException : ApiExceptionBase
{
    public ConflictApiException(string message = "Conflict", IDictionary<string, object>? extensions = null)
        : base(message, ApiStatusCode.Conflict, extensions)
    { }
}
