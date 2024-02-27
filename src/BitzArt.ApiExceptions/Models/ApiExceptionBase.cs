using Keys = BitzArt.ApiExceptions.ApiExceptionPayload.Keys;

namespace BitzArt.ApiExceptions;

public abstract partial class ApiExceptionBase : Exception
{
    public int StatusCode { get; set; }

    public ApiExceptionPayload Payload { get; }

    protected ApiExceptionBase
        (
        string message = "Unexpected Error",
        ApiStatusCode statusCode = ApiStatusCode.Error,
        string? errorType = null,
        ApiExceptionPayload? payload = null,
        Exception? innerException = null)
        : this(message, (int)statusCode, errorType, payload, innerException)
    { }

    protected ApiExceptionBase
        (
        string message,
        int statusCode,
        string? errorType = null,
        ApiExceptionPayload? payload = null,
        Exception? innerException = null)
        : base(message, innerException)
    {
        StatusCode = statusCode;
        Payload = payload ?? new();
        if (errorType is not null) ErrorType = errorType;
    }

    public string? ErrorType
    {
        get => Payload.GetDataEntry<string?>(Keys.ErrorType);
        set => Payload.AddData(Keys.ErrorType, value!);
    }

    public string? Detail
    {
        get => Payload.GetDataEntry<string?>(Keys.Detail);
        set => Payload.AddData(Keys.Detail, value!);
    }

    public string? Instance
    {
        get => Payload.GetDataEntry<string?>(Keys.Instance);
        set => Payload.AddData(Keys.Instance, value!);
    }

    public bool? UseDefaultErrorTypeValue
    {
        get => Payload.GetConfigurationEntry<bool?>(Keys.UseDefaultErrorType);
        set => Payload.AddConfiguration(Keys.UseDefaultErrorType, value!);
    }
}
