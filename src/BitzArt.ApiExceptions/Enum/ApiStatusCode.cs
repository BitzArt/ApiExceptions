namespace BitzArt.ApiExceptions;

/// <summary>
/// API status codes.
/// </summary>
public enum ApiStatusCode : int
{
    /// <summary>
    /// Success API status code.
    /// </summary>
    OK = 200,

    /// <summary>
    /// Created API status code.
    /// </summary>
    Created = 201,

    /// <summary>
    /// Accepted API status code.
    /// </summary>
    Accepted = 202,

    /// <summary>
    /// No content API status code.
    /// </summary>
    NoContent = 204,


    /// <summary>
    /// Bad request API status code.
    /// </summary>
    BadRequest = 400,

    /// <summary>
    /// Unauthorized API status code.
    /// </summary>
    Unauthorized = 401,

    /// <summary>
    /// Payment required API status code.
    /// </summary>
    PaymentRequired = 402,

    /// <summary>
    /// Forbidden API status code.
    /// </summary>
    Forbidden = 403,

    /// <summary>
    /// Not found API status code.
    /// </summary>
    NotFound = 404,

    /// <summary>
    /// Method not allowed API status code.
    /// </summary>
    MethodNotAllowed = 405,

    /// <summary>
    /// Not acceptable API status code.
    /// </summary>
    NotAcceptable = 406,

    /// <summary>
    /// Conflict API status code.
    /// </summary>
    Conflict = 409,

    /// <summary>
    /// Failed dependency API status code.
    /// </summary>
    FailedDependency = 424,

    /// <summary>
    /// Too many requests API status code.
    /// </summary>
    TooManyRequests = 429,

    /// <summary>
    /// Error API status code.
    /// </summary>
    Error = 500,

    /// <summary>
    /// NotImplemented API status code.
    /// </summary>
    NotImplemented = 501,

    /// <summary>
    /// Service unavailable API status code.
    /// </summary>
    ServiceUnavailable = 503,
}
