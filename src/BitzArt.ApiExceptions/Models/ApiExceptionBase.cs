namespace BitzArt.ApiExceptions;

public abstract partial class ApiExceptionBase : Exception
{
    public int StatusCode { get; set; }

    public ApiExceptionPayload Payload { get; }

    protected ApiExceptionBase
        (
        string message = "Unexpected Error",
        ApiStatusCode statusCode = ApiStatusCode.Error,
        ApiExceptionPayload? payload = null,
        Exception? innerException = null)
        : this(message, (int)statusCode, payload, innerException)
    { }

    protected ApiExceptionBase
        (
        string message,
        int statusCode,
        ApiExceptionPayload? payload = null,
        Exception? innerException = null)
        : base(message, innerException)
    {
        StatusCode = statusCode;
        Payload = payload ?? new();
    }
}
