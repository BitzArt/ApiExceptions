namespace BitzArt.ApiExceptions.Enum
{
    public enum ApiStatusCode : int
    {
        OK = 200,
        Created = 201,
        Accepted = 202,
        NoContent = 204,

        BadRequest = 400,
        Unauthorized = 401,
        PaymentRequired = 402,
        Forbidden = 403,
        NotFound = 404,
        MethodNotAllowed = 405,
        NotAcceptable = 406,
        Conflict = 409,
        FailedDependency = 424,
        TooManyRequests = 429,

        Error = 500,
        NotImplemented = 501,
        ServiceUnavailable = 503,
    }
}
