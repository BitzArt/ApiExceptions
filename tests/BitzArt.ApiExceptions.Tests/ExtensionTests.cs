namespace BitzArt.ApiExceptions.Tests;

public class ExtensionTests
{
    [Theory]
    [InlineData("SomeKey", "SomeValue")]
    [InlineData("Integer", 12345)]
    [InlineData("PassingNull", null)]
    public void Add_WithKeyAndValue_AddsToExtensions(string key, object value)
    {
        var sut = new Sut();
        sut.AddExtensions(key, value);

        var added = sut.Extensions.Single();
        Assert.True(added.Key == key);
        Assert.True(added.Value == value);
    }

    [Fact]
    public void Add_WithComplexObject_AddsToExtensions()
    {
        var sut = new Sut();

        var inner = new { a = "something", b = "something else" };
        var complex = new { outter = "this", inner };

        sut.AddExtensions(complex);

        Assert.Contains(sut.Extensions, x => x.Key == "outter" && (string)x.Value == "this");
        Assert.Contains(sut.Extensions, x => x.Key == "inner" && x.Value == inner);
    }

    private class Sut : ApiExceptionBase
    {
        public Sut() : base() { }
    }
}