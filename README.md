To use with Asp.Net Core, add nuget package to your project:

https://www.nuget.org/packages/BitzArt.ApiExceptions.AspNetCore/

Add this code to your Startup.Configure method:

    app.ConfigureApiExceptionHandler();
  
Then, anywhere in your code, you can throw exceptions like:

    throw new NotFoundException("response message here");
    
This will get converted into a http request with appropriate status code (in this case - 404).

For any custom status codes you can use ApiException class:

    throw new ApiException(HttpStatusCode.Forbidden, "your message");
    
List of implemented exceptions will be availiable later. For now you can see file names in source code.
