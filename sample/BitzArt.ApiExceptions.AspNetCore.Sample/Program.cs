using BitzArt;
using BitzArt.ApiExceptions.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddApiExceptionHandler(options =>
{
    // Disable using default values for 'type' field
    options.DisableDefaultTypeValues = true; 

    // Enables all request logging
    options.EnableRequestLogging = true;

    // Enables logging of handled exceptions
    options.EnableErrorLogging = true;

    // Adds Inner Exceptions to error responses recursively
    options.AddInnerExceptions = true;
});

// Reports all exceptions that occured in your application to OpenTelemetry
ExceptionTelemetry.EnableOpenTelemetry();

var app = builder.Build();

// This will add a global exception handler to your request pipeline.
// You can also use ApiExceptionFilter attribute instead.
app.UseApiExceptionHandler();

app.MapControllers();

app.Run();
