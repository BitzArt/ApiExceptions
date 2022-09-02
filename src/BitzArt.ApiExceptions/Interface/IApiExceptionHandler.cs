namespace BitzArt.ApiExceptions;

public interface IApiExceptionHandler
{
    Task HandleAsync(Exception exception);
}