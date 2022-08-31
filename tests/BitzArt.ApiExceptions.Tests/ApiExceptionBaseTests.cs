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
    [InlineData("message 1", ApiStatusCode.Error)]
    [InlineData("this is a longer message with some numbers 12345", (ApiStatusCode)12345)]
    public void Ctor_WithParams_ConstructsProperly(string msg, ApiStatusCode statusCode)
    {
        var sut = new Sut(msg, statusCode);
        Assert.Equal(msg, sut.Message);
        Assert.Equal((int)statusCode, sut.StatusCode);
    }

    private class Sut : ApiExceptionBase
    {
        public Sut() : base() { }
        public Sut(string message, ApiStatusCode statusCode = ApiStatusCode.Error)
            : base(message, statusCode) { }
    }
}