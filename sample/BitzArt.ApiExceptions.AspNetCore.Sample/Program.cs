using BitzArt;
using BitzArt.ApiExceptions.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddApiExceptionHandler(options =>
{
    // Disable using default values for 'type' field
    options.DisableDefaultTypeValues = true; 

    // Enable all request logging
    options.EnableRequestLogging = true;

    // Enable logging of exceptions handled in the middleware
    options.EnableErrorLogging = true;

    // Adds Inner Exceptions to error responses recursively
    options.AddInnerExceptions = true;
});

ExceptionTelemetry.EnableOpenTelemetry();

var app = builder.Build();

app.UseApiExceptionHandler();
app.MapControllers();

app.Run();
