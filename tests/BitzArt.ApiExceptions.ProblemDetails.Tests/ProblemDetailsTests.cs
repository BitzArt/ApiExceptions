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

            Assert.Null(pd.ErrorType);
            Assert.Null(pd.Detail);
            Assert.Null(pd.Instance);

            Assert.False(pd.Extensions.Any());
        }

        [Fact]
        public void Ctor_FromApiException_ReturnsProper()
        {
            var msg = "some text here";
            var exception = new CustomApiException(msg);
            var pd = new ProblemDetails(exception);

            Assert.Equal(pd.Title, msg);

            Assert.Null(pd.ErrorType);
            Assert.Null(pd.Detail);
            Assert.Null(pd.Instance);

            Assert.False(pd.Extensions.Any());
        }

        [Fact]
        public void AddErrorType_OnApiException_EndsUpInProblemDetails()
        {
            var exception = new CustomApiException();
            var errorType = "some error type here";
            exception.Payload.SetErrorType(errorType);
            var pd = new ProblemDetails(exception);

            Assert.Equal(pd.ErrorType, errorType);

            Assert.Null(pd.Detail);
            Assert.Null(pd.Instance);

            Assert.False(pd.Extensions.Any());
        }

        [Fact]
        public void AddDetail_OnApiException_EndsUpInProblemDetails()
        {
            var exception = new CustomApiException();
            var detail = "some detail here";
            exception.Payload.SetDetail(detail);
            var pd = new ProblemDetails(exception);

            Assert.Equal(pd.Detail, detail);

            Assert.Null(pd.ErrorType);
            Assert.Null(pd.Instance);

            Assert.False(pd.Extensions.Any());
        }

        [Fact]
        public void AddInstance_OnApiException_EndsUpInProblemDetails()
        {
            var exception = new CustomApiException();
            var instance = "some instance here";
            exception.Payload.SetInstance(instance);
            var pd = new ProblemDetails(exception);

            Assert.Equal(pd.Instance, instance);

            Assert.Null(pd.ErrorType);
            Assert.Null(pd.Detail);

            Assert.False(pd.Extensions.Any());
        }

        [Theory]
        [InlineData("someKey", "someValue")]
        [InlineData("integer", 123)]
        public void AddExtensions_OnApiException_EndsUpInProblemDetails(string key, object value)
        {
            var exception = new CustomApiException();
            exception.Payload.AddData(key, value);
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