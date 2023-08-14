namespace BitzArt.ApiExceptions.AspNetCore;

public class ApiExceptionHandlerOptions
{
    public bool DisableDefaultTypeValues { get; set; } = false;
    public bool EnableRequestLogging { get; set; } = false;
    public bool EnableErrorLogging { get; set; } = false;
}
