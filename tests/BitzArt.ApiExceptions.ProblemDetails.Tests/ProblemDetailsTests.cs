namespace BitzArt.ApiExceptions
{
    public class ProblemDetailsTests
    {
        [Fact]
        public void Ctor_FromException_ReturnsProper()
        {
            var msg = "some text here";
            var exception = new Exception(msg);
            var pd = new ProblemDetails(exception);

            Assert.Equal(pd.Title, msg);
            Assert.Null(pd.Instance);
            Assert.Null(pd.Detail);
            Assert.Null(pd.ErrorType);
            Assert.False(pd.Extensions.Any());
        }

        [Fact]
        public void Ctor_FromApiException_ReturnsProper()
        {
            var msg = "some text here";
            var exception = new CustomApiException(msg);
            var pd = new ProblemDetails(exception);

            Assert.Equal(pd.Title, msg);
            var uri = new Uri(pd.ErrorType!);
            Assert.Null(pd.Instance);
            Assert.Null(pd.Detail);
            Assert.False(pd.Extensions.Any());
        }

        [Fact]
        public void AddErrorType_OnApiException_EndsUpInProblemDetails()
        {
            var exception = new CustomApiException();
            var errorType = "some error type here";
            exception.AddErrorType(errorType);
            var pd = new ProblemDetails(exception);

            Assert.Equal(pd.ErrorType, errorType);
            Assert.DoesNotContain(pd.Extensions,
                x => x.Value is string stringValue && stringValue == errorType);
        }

        [Fact]
        public void AddDetail_OnApiException_EndsUpInProblemDetails()
        {
            var exception = new CustomApiException();
            var detail = "some detail here";
            exception.AddDetail(detail);
            var pd = new ProblemDetails(exception);

            Assert.Equal(pd.Detail, detail);
            Assert.DoesNotContain(pd.Extensions,
                x => x.Value is string stringValue && stringValue == detail);
        }

        [Fact]
        public void AddInstance_OnApiException_EndsUpInProblemDetails()
        {
            var exception = new CustomApiException();
            var instance = "some instance here";
            exception.AddInstance(instance);
            var pd = new ProblemDetails(exception);

            Assert.Equal(pd.Instance, instance);
            Assert.DoesNotContain(pd.Extensions,
                x => x.Value is string stringValue && stringValue == instance);
        }

        [Theory]
        [InlineData("someKey", "someValue")]
        [InlineData("integer", 123)]
        public void AddExtensions_OnApiException_EndsUpInProblemDetails(string key, object value)
        {
            var exception = new CustomApiException();
            exception.AddExtensions(key, value);
            var pd = new ProblemDetails(exception);

            Assert.Contains(pd.Extensions, x => x.Key == key && x.Value == value);
        }

        private class CustomApiException : ApiExceptionBase
        {
            public CustomApiException() : base() { }
            public CustomApiException(string message) : base(message) { }
        }
    }
}