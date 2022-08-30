namespace BitzArt.ApiExceptions;

public static class ErrorTypeExtensions
{
    public static void AddErrorType(this ApiExceptionBase exception, string value)
        => exception.AddExtensions(Config.ErrorTypeKey, value);

    public static void UseDefaultTypeValue(this ApiExceptionBase exception, bool value)
        => exception.AddExtensions(Config.UseDefaultErrorTypeKey, value);

    public static string? GetErrorType(this ApiExceptionBase exception)
        => exception.GetExtension<string?>(Config.ErrorTypeKey);

    public static bool? GetUseDefaultTypeValue(this ApiExceptionBase exception)
        => exception.GetExtension<bool?>(Config.UseDefaultErrorTypeKey);
}
