namespace BitzArt.ApiExceptions.AspNetCore.Sample;

public class MyCustomApiException : ApiExceptionBase
{
    public MyCustomApiException() : base("custom error message", 420)
    {
        Payload.SetErrorType("http://example.com/link-to-error-info");
        Payload.SetDetail("additional details");
    }
}
