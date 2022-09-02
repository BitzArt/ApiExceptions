using BitzArt.ApiExceptions.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddApiExceptionHandler(options =>
{
    // Disables using default values for 'type' field
    options.DisableDefaultTypeValues = true; 
});

var app = builder.Build();

app.UseApiExceptionHandler();
app.MapControllers();

app.Run();
