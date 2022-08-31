namespace BitzArt.ApiExceptions
{
    internal static class Config
    {
        internal const string DocumentationLink = "https://developer.mozilla.org/en-US/docs/Web/HTTP/Status";

        internal const string ErrorTypeKey = "type";
        internal const string UseDefaultErrorTypeKey = "useDefaultType";
        internal const string DetailKey = "detail";
        internal const string InstanceKey = "instance";

        internal static IEnumerable<string> ReservedKeys => new HashSet<string>
        {
            ErrorTypeKey,
            UseDefaultErrorTypeKey,
            DetailKey,
            InstanceKey
        };
    }
}
