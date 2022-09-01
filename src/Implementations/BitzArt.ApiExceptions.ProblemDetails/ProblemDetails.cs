using System.Text.Json.Serialization;

namespace BitzArt.ApiExceptions;

public class ProblemDetails
{
    public static class Keys
    {
        public const string Title = "title";
        public const string ErrorType = "type";
        public const string Detail = "detail";
        public const string Instance = "instance";
    }

    [JsonExtensionData]
    public IDictionary<string, object> Data { get; set; }

    public ProblemDetails(ApiExceptionBase exception)
        : this(exception, exception.Payload.Data)
    {
    }

    public ProblemDetails(Exception exception, IDictionary<string, object>? data = null)
        : this(exception.Message, data)
    {
        if (exception.InnerException is not null) Data.Add(Keys.Detail, exception.InnerException.Message);
    }

    public ProblemDetails(string? message = null, IDictionary<string, object>? data = null)
    {
        Data = data ?? new Dictionary<string, object>();
        if (!string.IsNullOrWhiteSpace(message)) Data.Add(Keys.Title, message);
    }
}
