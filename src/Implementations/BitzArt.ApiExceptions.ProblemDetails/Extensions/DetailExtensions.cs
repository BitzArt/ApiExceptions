namespace BitzArt.ApiExceptions;

public static class DetailExtensions
{
    public static void AddDetail(this ApiExceptionBase exception, string value)
        => exception.AddExtensions(Config.DetailKey, value);

    public static string? GetDetail(this ApiExceptionBase exception)
        => exception.GetExtension<string?>(Config.DetailKey);
}
