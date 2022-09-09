namespace BitzArt.ApiExceptions.AspNetCore.Sample;

public class MyCustomApiException : ApiExceptionBase
{
    public MyCustomApiException() : base("custom error message", 420)
    {
        ErrorType = "http://example.com/link-to-error-info";
        Detail = "additional details";
    }
}
