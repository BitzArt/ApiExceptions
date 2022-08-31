namespace BitzArt.ApiExceptions.AspNetCore.Sample;

public class MyCustomPayloadApiException : ApiExceptionBase
{
    public MyCustomPayloadApiException()
    {
        var extraData = new CustomPayload();
        Payload.Add(extraData);
    }
}
