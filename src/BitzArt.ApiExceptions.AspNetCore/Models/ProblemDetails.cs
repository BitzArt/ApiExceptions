using System.Text.Json.Serialization;
using Keys = BitzArt.ApiExceptions.ApiExceptionPayload.Keys;

namespace BitzArt.ApiExceptions;

public class ProblemDetails
{
    private static IEnumerable<string> ReservedKeys => new List<string>
    {
        Keys.Title,
        Keys.ErrorType,
        Keys.Detail,
        Keys.Instance
    };

    [JsonPropertyName(Keys.Title)]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Title { get; set; }

    [JsonPropertyName(Keys.ErrorType)]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ErrorType { get; set; }

    [JsonPropertyName(Keys.Detail)]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Detail { get; set; }

    [JsonPropertyName(Keys.Instance)]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Instance { get; set; }

    [JsonExtensionData]
    public IDictionary<string, object> Extensions { get; set; }

    public ProblemDetails(ApiExceptionBase exception)
        : this(exception, exception.Payload.Data)
    {
    }

    public ProblemDetails(Exception exception, IDictionary<string, object>? data = null)
        : this(exception.Message, data)
    {
        if (exception.InnerException is not null) Extensions.Add("inner", exception.InnerException.Message);
    }

    public ProblemDetails(string? message = null, IDictionary<string, object>? data = null)
    {
        Extensions = new Dictionary<string, object>();
        ParseData(data);
        if (!string.IsNullOrWhiteSpace(message)) Title = message;
    }

    private void ParseData(IDictionary<string, object>? data)
    {
        if (data is null) return;

        if (data.ContainsKey(Keys.ErrorType)) ErrorType = (string)data[Keys.ErrorType];
        if (data.ContainsKey(Keys.Detail)) Detail = (string)data[Keys.Detail];
        if (data.ContainsKey(Keys.Instance)) Instance = (string)data[Keys.Instance];

        foreach (var entry in data)
        {
            if (ReservedKeys.Contains(entry.Key)) continue;
            Extensions.Add(entry.Key, entry.Value);
        }
    }
}
