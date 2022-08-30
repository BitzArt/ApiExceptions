To use with Asp.Net Core, add nuget package to your project:

https://www.nuget.org/packages/BitzArt.ApiExceptions.AspNetCore/

Add this code to your Startup.Configure method before controllers:

````csharp
app.ConfigureApiExceptionHandler();
````
Then, anywhere in your code, you can throw exceptions like:
````csharp
throw ApiException.NotFound("response message here");
````
This will get converted into a http request with appropriate status code (in this case - 404).
