namespace BitzArt.ApiExceptions;

public abstract partial class ApiExceptionBase : Exception
{
    public int StatusCode { get; set; }

    public ApiExceptionPayload Payload { get; }

    protected ApiExceptionBase
        (string message = "Unexpected Error", ApiStatusCode statusCode = ApiStatusCode.Error, ApiExceptionPayload? payload = null)
        : this(message, (int)statusCode, payload)
    { }

    protected ApiExceptionBase
        (string message, int statusCode, ApiExceptionPayload? payload = null)
        : base(message)
    {
        StatusCode = statusCode;
        Payload = payload ?? new();

        ApiException.Events.RaiseApiExceptionThrown(this);
    }
}
