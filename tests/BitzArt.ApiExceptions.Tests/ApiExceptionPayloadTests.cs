namespace BitzArt.ApiExceptions.Tests;

public class ApiExceptionPayloadTests
{
    [Theory]
    [InlineData("SomeKey", "SomeValue")]
    [InlineData("Integer", 12345)]
    public void Add_WithKeyAndValue_AddsToExtensions(string key, object value)
    {
        var sut = new Sut();
        sut.Payload.Add(key, value);

        var added = sut.Payload.Data.Single();
        Assert.True(added.Key == key);
        Assert.True(added.Value == value);
    }

    [Fact]
    public void Add_WithComplexObject_AddsToExtensions()
    {
        var sut = new Sut();

        var inner = new { a = "something", b = "something else" };
        var complex = new { outter = "this", inner };

        sut.Payload.Add(complex);

        Assert.Contains(sut.Payload.Data, x => x.Key == "outter");
        Assert.Contains(sut.Payload.Data, x => x.Key == "inner");
    }

    private class Sut : ApiExceptionBase
    {
        public Sut() : base() { }
    }
}