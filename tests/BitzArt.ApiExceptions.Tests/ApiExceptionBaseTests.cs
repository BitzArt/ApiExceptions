namespace BitzArt.ApiExceptions.Tests;

public class ApiExceptionBaseTests
{
    [Fact]
    public void Ctor_Default_ConstructsProperly()
    {
        var sut = new Sut();
        Assert.Equal("Unexpected Error", sut.Message);
        Assert.Equal((int)ApiStatusCode.Error, sut.StatusCode);
    }

    [Theory]
    [InlineData("error message", ApiStatusCode.Error)]
    [InlineData("error message", (ApiStatusCode)12345)]
    [InlineData("this is a longer error message this is a longer error message this is a longer error message", ApiStatusCode.Error)]
    [InlineData("1234567890!@#$%^&*()[]", ApiStatusCode.Error)]
    public void Ctor_WithParams_ConstructsProperly(string msg, ApiStatusCode statusCode)
    {
        var sut = new Sut(msg, statusCode);
        Assert.Equal(msg, sut.Message);
        Assert.Equal((int)statusCode, sut.StatusCode);
    }

    [Fact]
    public void Ctor_WithErrorType_AddsErrorTypeToPayload()
    {
        var errorType = "some error type";
        var sut = new InternalErrorApiException("some message", errorType);
        Assert.Equal(errorType, sut.ErrorType);
    }

    private class Sut : ApiException
    {
        public Sut() : base() { }
        public Sut(string message, ApiStatusCode statusCode = ApiStatusCode.Error)
            : base(message, statusCode) { }
    }
}