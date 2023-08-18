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
        public void CtorFromExceptionWithInnerException_NotIncludeInner_ReturnsProper()
        {
            var innerLevel3 = new Exception("Level 3");
            var innerLevel2 = new Exception("Level 2", innerLevel3);
            var innerLevel1 = new Exception("Level 1", innerLevel2);
            var outter = new Exception("Outter", innerLevel1);

            var problemDetails = new ProblemDetails(outter, addInner: false);

            Assert.False(problemDetails.Extensions.Any());
        }

        [Fact]
        public void CtorFromExceptionWithInnerException_IncludeInner_ReturnsProper()
        {
            var innerLevel3 = new Exception("Level 3");
            var innerLevel2 = new Exception("Level 2", innerLevel3);
            var innerLevel1 = new Exception("Level 1", innerLevel2);
            var outter = new Exception("Outter", innerLevel1);

            var problemDetails = new ProblemDetails(outter, addInner: true);

            Assert.True(problemDetails.Extensions.Any());
            Assert.Contains(problemDetails.Extensions, x => x.Key == "inner");

            var level1 = (problemDetails.Extensions.First().Value as IDictionary<string, object>)!;
            Assert.True(level1.Any());
            Assert.Contains(level1, x => x.Key == "title");
            Assert.Contains(level1, x => x.Key == "inner");

            var level2 = (level1.First(x => x.Key == "inner").Value as IDictionary<string, object>)!;
            Assert.True(level2.Any());
            Assert.Contains(level2, x => x.Key == "title");
            Assert.Contains(level2, x => x.Key == "inner");

            var level3 = (level2.First(x => x.Key == "inner").Value as IDictionary<string, object>)!;
            Assert.True(level3.Any());
            Assert.Contains(level3, x => x.Key == "title");

            Assert.DoesNotContain(level3, x => x.Key == "inner");
        }

        [Fact]
        public void AddErrorType_OnApiException_EndsUpInProblemDetails()
        {
            var exception = new CustomApiException();
            var errorType = "some error type here";
            exception.ErrorType = errorType;
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
            exception.Detail = detail;
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
            exception.Instance = instance;
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