using BitzArt.ApiExceptions.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add ApiExceptionHandler to the service collection
// and configure it's behavior using the options.
builder.Services.AddApiExceptionHandler(options =>
{
    // Disable using default values for the 'type' field
    options.DisableDefaultTypeValues = true;

    // Enables logging of all incoming requests
    options.LogRequests = true;

    // Enables logging of handled exceptions
    options.LogExceptions = true;

    // Adds inner exceptions to error responses recursively
    options.DisplayInnerExceptions = true;

    // Disables adding the default 'status' values
    // (equal to http status codes)
    // to the ProblemDetails response
    options.DisableDefaultProblemDetailsStatusValue = false;
});

builder.Services.AddControllers();

var app = builder.Build();

// This will add a global exception handler middleware to your request pipeline.
// This middleware should be added before any other middleware that might throw exceptions.
// The middleware will handle all exceptions
// (including both ApiExceptions and regular Exceptions)
// and return a ProblemDetails response.
app.UseApiExceptionHandler();

// In this example, controllers are a source of exceptions.
app.MapControllers();

app.Run();
