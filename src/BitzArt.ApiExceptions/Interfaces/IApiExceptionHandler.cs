namespace BitzArt.ApiExceptions;

/// <summary>
/// API exception handler.
/// </summary>
public interface IApiExceptionHandler
{
    /// <summary>
    /// Handles the exception.
    /// </summary>
    Task HandleAsync(Exception exception);
}