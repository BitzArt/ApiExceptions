using System.Text.Json.Serialization;

namespace BitzArt.ApiExceptions.AspNetCore.Sample
{
    public class CustomPayload
    {
        [JsonPropertyName("text")]
        public string SomeProperty { get; set; } = "some text";

        [JsonPropertyName("number")]
        public int SomeNumber { get; set; } = 123;

        [JsonPropertyName("bool")]
        public bool SomeBool { get; set; } = true;
    }
}
