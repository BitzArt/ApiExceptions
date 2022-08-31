namespace BitzArt.ApiExceptions;

public static class ApiExceptionPayloadExtensions
{
    // Waiting for extension properties to be implemented
    // https://stackoverflow.com/questions/619033/does-c-sharp-have-extension-properties

    // Detail ==================================================================

    public static void SetDetail(this ApiExceptionPayload payload, string value)
        => payload.Add(Config.DetailKey, value);

    public static string? GetDetail(this ApiExceptionPayload payload)
        => payload.Get<string?>(Config.DetailKey);

    // ErrorType ===============================================================

    public static void SetErrorType(this ApiExceptionPayload payload, string value)
        => payload.Add(Config.ErrorTypeKey, value);

    public static string? GetErrorType(this ApiExceptionPayload payload)
        => payload.Get<string?>(Config.ErrorTypeKey);

    // UseDefaultErrorType =====================================================

    public static void SetUseDefaultErrorTypeValue(this ApiExceptionPayload payload, bool value)
        => payload.Add(Config.UseDefaultErrorTypeKey, value);

    public static bool? GetUseDefaultErrorTypeValue(this ApiExceptionPayload payload)
        => payload.Get<bool?>(Config.UseDefaultErrorTypeKey);

    // Instance ================================================================

    public static void SetInstance(this ApiExceptionPayload payload, string value)
        => payload.Add(Config.InstanceKey, value);

    public static string? GetInstance(this ApiExceptionPayload payload)
        => payload.Get<string?>(Config.InstanceKey);
}
