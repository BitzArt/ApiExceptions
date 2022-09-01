using BitzArt.ApiExceptions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

var app = builder.Build();

app.UseApiExceptionHandler();
app.MapControllers();

app.Run();
