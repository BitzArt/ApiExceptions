using BitzArt.ApiExceptions.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

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
});

var app = builder.Build();

// This will add a global exception handler middleware to your request pipeline.
// Use this before using your controllers as middleware order matters.
app.UseApiExceptionHandler();

app.MapControllers();

app.Run();
