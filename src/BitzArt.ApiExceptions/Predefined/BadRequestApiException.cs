namespace BitzArt.ApiExceptions;

public class BadRequestApiException : ApiExceptionBase
{
    public BadRequestApiException(string message = "Bad request", IDictionary<string, object>? extensions = null)
        : base(message, ApiStatusCode.BadRequest, extensions)
    { }
}
