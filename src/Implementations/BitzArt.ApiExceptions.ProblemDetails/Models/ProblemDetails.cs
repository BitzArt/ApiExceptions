using System.Text.Json.Serialization;

namespace BitzArt.ApiExceptions;

public class ProblemDetails
{
    [JsonPropertyName("title")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Title { get; set; }

    [JsonPropertyName("type")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ErrorType { get; set; }

    [JsonPropertyName("detail")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Detail { get; set; }

    [JsonPropertyName("instance")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Instance { get; set; }

    [JsonExtensionData]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IDictionary<string, object> Extensions { get; set; }

    public ProblemDetails(ApiExceptionBase apiException)
        : this(apiException.Message, GetProblemType(apiException), apiException.GetDetail(), apiException.GetInstance(), apiException.Extensions)
    {
    }

    public ProblemDetails(Exception exception)
        : this(exception.Message)
    {
        if (exception.InnerException is not null) Detail = exception.InnerException.Message;
    }

    public ProblemDetails(string? title, string? errorType = null, string? detail = null, string? instance = null, IDictionary<string, object>? extensions = null)
    {
        ErrorType = errorType;
        Title = title;
        Detail = detail;
        Instance = instance;
        ReadExtensions(extensions);
    }

    private void ReadExtensions(IDictionary<string, object>? extensions)
    {
        if (extensions is null || !extensions.Any())
        {
            Extensions = new Dictionary<string, object>();
            return;
        }

        var extra = extensions
                .Where(x => !Config.SpecialKeys.Contains(x.Key));
        Extensions = new Dictionary<string, object>(extra);
    }

    public static string? GetProblemType(ApiExceptionBase exception)
    {
        var errorType = exception.GetErrorType();
        if (errorType is not null) return errorType;

        var useDefault = exception.GetUseDefaultTypeValue();
        if (useDefault.HasValue && useDefault == false) return null;
        return $"{Config.DocumentationLink}/{exception.StatusCode}";
    }
}
