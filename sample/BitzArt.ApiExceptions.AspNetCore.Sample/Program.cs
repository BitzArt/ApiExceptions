var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapControllers();

app.Run();
