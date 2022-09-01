namespace BitzArt.ApiExceptions;

public static class ApiExceptionPayloadExtensions
{
    // Waiting for extension properties to be implemented
    // https://stackoverflow.com/questions/619033/does-c-sharp-have-extension-properties

    // ErrorType ===============================================================

    public static void SetErrorType(this ApiExceptionPayload payload, string value)
        => payload.AddData(ProblemDetails.Keys.ErrorType, value);

    public static string? GetErrorType(this ApiExceptionPayload payload)
        => payload.GetDataEntry<string?>(ProblemDetails.Keys.ErrorType);

    // Detail ==================================================================

    public static void SetDetail(this ApiExceptionPayload payload, string value)
        => payload.AddData(ProblemDetails.Keys.Detail, value);

    public static string? GetDetail(this ApiExceptionPayload payload)
        => payload.GetDataEntry<string?>(ProblemDetails.Keys.Detail);

    // Instance ================================================================

    public static void SetInstance(this ApiExceptionPayload payload, string value)
        => payload.AddData(ProblemDetails.Keys.Instance, value);

    public static string? GetInstance(this ApiExceptionPayload payload)
        => payload.GetDataEntry<string?>(ProblemDetails.Keys.Instance);
}
