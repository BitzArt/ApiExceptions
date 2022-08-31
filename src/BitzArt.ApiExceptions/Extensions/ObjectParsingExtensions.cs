using System.Text.Json;

namespace BitzArt.ApiExceptions;

internal static class ObjectParsingExtensions
{
    internal static IEnumerable<KeyValuePair<string, object>>? ParseAsExtensions(this object? value)
    {
        var json = JsonSerializer.Serialize(value);
        return JsonSerializer.Deserialize<IDictionary<string, object>>(json);
    }
}
