using System.Reflection;

namespace BitzArt.ApiExceptions;

internal static class ObjectParsingExtensions
{
    internal static IEnumerable<KeyValuePair<string, object>>? ParseAsExtensions(this object? extensions)
    {
        if (extensions is null) return null;

        var pairs = extensions
            .GetType()
            .GetProperties()
            .Select(x => ParseObjectProperty(extensions, x))
            .Where(x => x is not null);

        if (pairs is null || !pairs.Any()) return null;
        return pairs.Select(x => x!.Value);
    }

    private static KeyValuePair<string, object>? ParseObjectProperty(object? parent, PropertyInfo property)
    {
        var value = property.GetValue(parent, null);
        if (value is null) return null;
        return new KeyValuePair<string, object>(property.Name, value);
    }
}
