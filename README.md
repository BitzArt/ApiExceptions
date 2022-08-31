![Tests](https://github.com/BitzArt/ApiExceptions/actions/workflows/Tests.yml/badge.svg)


# General

This package defines `ApiExceptions` that can be thrown in any .Net applications.

These `ApiExceptions` contain payloads that can be used by handlers.

# Use with Asp.Net Core

This package contains a predefined handler for Asp.Net Core

To use with Asp.Net Core, add nuget package to your project:

https://www.nuget.org/packages/BitzArt.ApiExceptions.AspNetCore/

Add this code to your Startup.Configure method before controllers:

````csharp
app.ConfigureApiExceptionHandler();
````
Then, anywhere in your code, you can throw exceptions like:
````csharp
throw ApiException.NotFound("sample 'not found' message");
````
This will generate an http response with appropriate status code:

![404-screenshot](/docs/404-screenshot.png)

These responses follow [RFC7807: Problem Details](https://www.rfc-editor.org/rfc/rfc7807) standard.

For further guidance, see this [Asp.Net Core Sample project](https://github.com/BitzArt/ApiExceptions/tree/main/sample/BitzArt.ApiExceptions.AspNetCore.Sample)

# Use outside of Asp.Net Core

To use the exceptions in your applications, add this nuget package to your project:

https://www.nuget.org/packages/BitzArt.ApiExceptions/

The base package contains no handlers, so you will have to implement them yourself.

If you would like to work with ProblemDetails model, you can consider this package:

https://www.nuget.org/packages/BitzArt.ApiExceptions.ProblemDetails/
