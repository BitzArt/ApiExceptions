using BitzArt.ApiExceptions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

var app = builder.Build();

app.ConfigureApiExceptionHandler();
app.MapControllers();

app.Run();
