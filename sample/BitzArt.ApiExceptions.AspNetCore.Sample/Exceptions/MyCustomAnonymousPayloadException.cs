using System.Text.Json.Serialization;

namespace BitzArt.ApiExceptions.AspNetCore.Sample;

public class MyAnonymousPayloadApiException : ApiException
{
    private class SampleInnerObject
    {
        [JsonPropertyName("value")]
        public string Value { get; set; }

        public SampleInnerObject(string value)
        {
            Value = value;
        }
    }

    public MyAnonymousPayloadApiException()
    {
        var extraData = new
        {
            someString = "some value",
            someInteger = 12345,
            someGuid = Guid.NewGuid(),
            someInnerObject = new SampleInnerObject("sample value"),
            someArray = new List<string>
            {
                "object 1",
                "object 2",
                "object 3"
            }
        };

        Payload.AddData(extraData);
    }
}
