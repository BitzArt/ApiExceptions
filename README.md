![Tests](https://github.com/BitzArt/ApiExceptions/actions/workflows/Tests.yml/badge.svg)


# General

This library defines `ApiExceptions` that you can throw in your .Net applications.

# Use with Asp.Net Core

> 💡
> You can always refer to [this](https://github.com/BitzArt/ApiExceptions/tree/main/sample/BitzArt.ApiExceptions.AspNetCore.Sample) sample project for guidance.

## Setup:

Add the nuget package:

```
dotnet add package BitzArt.ApiExceptions.AspNetCore
```

Add this line to your `Program.cs` when configuring services:
```csharp
builder.Services.AddApiExceptionHandler();
```

Add this line to your `Program.cs` when configuring the request pipeline:
```csharp
// This line should go before any other middleware that might throw exceptions
app.UseApiExceptionHandler();
```

## Usage:
Then, anywhere in your code, you can throw exceptions like:
```csharp
throw ApiException.BadRequest("your error message");
```
This will stop any further execution and generate an http response with an appropriate http status code.

The package handles both ApiExceptions as well as regular Exceptions. If the exception is of type `ApiException`, it will generate a response with the appropriate status code and message. If the exception is of type `Exception`, the status code will be `500`.

> 💡
> These responses are aligned with [RFC7807: Problem Details for HTTP APIs](https://www.rfc-editor.org/rfc/rfc7807).

# Use outside of Asp.Net Core

To use `ApiExceptions` in your applications, add this nuget package to your project:

```
dotnet add package BitzArt.ApiExceptions
```

This will allow you to create and throw ApiExceptions, and you can then handle them as you see fit.
