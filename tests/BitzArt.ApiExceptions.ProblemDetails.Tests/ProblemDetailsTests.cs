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

            Assert.Equal(pd.Data[ProblemDetails.Keys.Title], msg);

            Assert.False(pd.Data.ContainsKey(ProblemDetails.Keys.ErrorType));
            Assert.False(pd.Data.ContainsKey(ProblemDetails.Keys.Detail));
            Assert.False(pd.Data.ContainsKey(ProblemDetails.Keys.Instance));
        }

        [Fact]
        public void Ctor_FromApiException_ReturnsProper()
        {
            var msg = "some text here";
            var exception = new CustomApiException(msg);
            var pd = new ProblemDetails(exception);

            var title = (string)pd.Data[ProblemDetails.Keys.Title];
            Assert.Equal(title, msg);

            Assert.False(pd.Data.ContainsKey(ProblemDetails.Keys.ErrorType));
            Assert.False(pd.Data.ContainsKey(ProblemDetails.Keys.Detail));
            Assert.False(pd.Data.ContainsKey(ProblemDetails.Keys.Instance));
        }

        [Fact]
        public void AddErrorType_OnApiException_EndsUpInProblemDetails()
        {
            var exception = new CustomApiException();
            var errorType = "some error type here";
            exception.Payload.SetErrorType(errorType);
            var pd = new ProblemDetails(exception);

            var type = (string)pd.Data[ProblemDetails.Keys.ErrorType];
            Assert.Equal(type, errorType);

            Assert.False(pd.Data.ContainsKey(ProblemDetails.Keys.Detail));
            Assert.False(pd.Data.ContainsKey(ProblemDetails.Keys.Instance));
        }

        [Fact]
        public void AddDetail_OnApiException_EndsUpInProblemDetails()
        {
            var exception = new CustomApiException();
            var detail = "some detail here";
            exception.Payload.SetDetail(detail);
            var pd = new ProblemDetails(exception);

            var entry = (string)pd.Data[ProblemDetails.Keys.Detail];
            Assert.Equal(entry, detail);

            Assert.False(pd.Data.ContainsKey(ProblemDetails.Keys.ErrorType));
            Assert.False(pd.Data.ContainsKey(ProblemDetails.Keys.Instance));
        }

        [Fact]
        public void AddInstance_OnApiException_EndsUpInProblemDetails()
        {
            var exception = new CustomApiException();
            var instance = "some instance here";
            exception.Payload.SetInstance(instance);
            var pd = new ProblemDetails(exception);

            var entry = (string)pd.Data[ProblemDetails.Keys.Instance];
            Assert.Equal(entry, instance);

            Assert.False(pd.Data.ContainsKey(ProblemDetails.Keys.ErrorType));
            Assert.False(pd.Data.ContainsKey(ProblemDetails.Keys.Detail));
        }

        [Theory]
        [InlineData("someKey", "someValue")]
        [InlineData("integer", 123)]
        public void AddExtensions_OnApiException_EndsUpInProblemDetails(string key, object value)
        {
            var exception = new CustomApiException();
            exception.Payload.AddData(key, value);
            var pd = new ProblemDetails(exception);

            Assert.Contains(pd.Data, x => x.Key == key && x.Value == value);
        }

        private class CustomApiException : ApiExceptionBase
        {
            public CustomApiException() : base() { }
            public CustomApiException(string message) : base(message) { }
        }
    }
}