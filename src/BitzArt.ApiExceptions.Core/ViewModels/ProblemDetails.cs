using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BitzArt.ApiExceptions
{
    public class ProblemDetails
    {
        [JsonPropertyName("type")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Type { get; set; }

        [JsonPropertyName("title")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Title { get; set; }

        [JsonPropertyName("detail")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Detail { get; set; }

        [JsonPropertyName("instance")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Instance { get; set; }

        [JsonExtensionData]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IDictionary<string, object?>? Extensions { get; set; }

        public ProblemDetails(ApiExceptionBase apiException) : this(apiException.Message, apiException.Type, apiException.Detail, apiException.Instance, apiException.Extensions) { }

        public ProblemDetails(Exception exception) : this(exception.Message)
        {
            if (exception.InnerException is not null) Detail = exception.InnerException.Message;
        }

        public ProblemDetails(string? title, string? type = null, string? detail = null, string? instance = null, IDictionary<string, object?>? extensions = null)
        {
            Type = type;
            Title = title;
            Detail = detail;
            Instance = instance;
            Extensions = extensions;
        }
    }
}
