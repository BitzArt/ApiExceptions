namespace BitzArt.ApiExceptions;

public static class ApiExceptionPayloadExtensions
{
    // Waiting for extension properties to be implemented
    // https://stackoverflow.com/questions/619033/does-c-sharp-have-extension-properties

    // UseDefaultErrorType =====================================================

    public static void SetUseDefaultErrorTypeValue(this ApiExceptionPayload payload, bool value)
        => payload.AddConfiguration(Config.UseDefaultErrorTypeKey, value);

    public static bool? GetUseDefaultErrorTypeValue(this ApiExceptionPayload payload)
        => payload.GetConfigurationEntry<bool?>(Config.UseDefaultErrorTypeKey);
}
