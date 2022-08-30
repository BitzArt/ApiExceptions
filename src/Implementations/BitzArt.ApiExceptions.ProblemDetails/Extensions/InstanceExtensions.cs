namespace BitzArt.ApiExceptions;

public static class InstanceExtensions
{
    public static void AddInstance(this ApiExceptionBase exception, string value)
        => exception.AddExtensions(Config.InstanceKey, value);

    public static string? GetInstance(this ApiExceptionBase exception)
        => exception.GetExtension<string?>(Config.InstanceKey);
}
