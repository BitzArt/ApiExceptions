namespace BitzArt.ApiExceptions.AspNetCore.Sample;

public class MyCustomApiException : ApiExceptionBase
{
    public MyCustomApiException() : base("custom error message", 420)
    {
        // Disables default "Type" values in ProblemDetails
        Payload.SetUseDefaultErrorTypeValue(false);

        Payload.SetErrorType("http://example.com/link-to-error-info");
        Payload.SetDetail("additional details");
    }
}
