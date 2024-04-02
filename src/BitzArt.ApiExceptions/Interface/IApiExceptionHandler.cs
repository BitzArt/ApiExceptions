namespace BitzArt.ApiExceptions;

/// <summary>
/// API exception handler.
/// </summary>
public interface IApiExceptionHandler
{
    /// <summary>
    /// Handles the exception, whether it is an <see cref="ApiExceptionBase">ApiException</see> or a regular <see cref="Exception"/>
    /// </summary>
    Task HandleAsync(Exception exception);
}