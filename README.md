![Tests](https://github.com/BitzArt/ApiExceptions/actions/workflows/Tests.yml/badge.svg)


# General

This library defines `ApiExceptions` that you can throw in your .Net applications.

# Use with Asp.Net Core

You can always refer to this [Asp.Net Core Sample project](https://github.com/BitzArt/ApiExceptions/tree/main/sample/BitzArt.ApiExceptions.AspNetCore.Sample) for guidance.

## Setup:

Add nuget package:

https://www.nuget.org/packages/BitzArt.ApiExceptions.AspNetCore/

Add these 2 lines of code to your `Program.cs`:
```csharp
builder.Services.AddApiExceptionHandler();
app.UseApiExceptionHandler();
```
## Usage:
Then, anywhere in your code, you can throw exceptions like:
```csharp
throw ApiException.NotFound("sample 'not found' message");
```
This will generate an http response with appropriate status code:

![404-screenshot](/docs/404-screenshot.png)

 ## Extra:
You can also add any custom fields:

![anonymous-screenshot](/docs/anonymous-screenshot.png)

These responses follow [RFC7807: Problem Details](https://www.rfc-editor.org/rfc/rfc7807) standard.

# Use outside of Asp.Net Core

To use the exceptions in your applications, add this nuget package to your project:

https://www.nuget.org/packages/BitzArt.ApiExceptions/

The base package contains no handlers, so you will have to implement them yourself.

If you would like to work with ProblemDetails model, you can consider this package:

https://www.nuget.org/packages/BitzArt.ApiExceptions.ProblemDetails/
