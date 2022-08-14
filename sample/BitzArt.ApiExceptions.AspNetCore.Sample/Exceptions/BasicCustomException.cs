namespace BitzArt.ApiExceptions.AspNetCore.Sample
{
    public class BasicCustomApiException : ApiExceptionBase
    {
        public BasicCustomApiException() : base("some message here") { }
    }
}
