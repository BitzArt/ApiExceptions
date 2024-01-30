using BitzArt.ApiExceptions;
using BitzArt.ApiExceptions.AspNetCore;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Net.Http;

namespace System;

internal static class ApiExceptionExtensions
{
    internal static ProblemDetails GetProblemDetails(this ApiExceptionBase apiException, HttpContext httpContext, ApiExceptionHandlerOptions options)
    {
        httpContext.Response.ContentType = "application/problem+json";
        httpContext.Response.StatusCode = apiException.StatusCode;

        var defaultErrorType = apiException.GetDefaultErrorType(options);
        if (defaultErrorType is not null) apiException.ErrorType = defaultErrorType;

        return new ProblemDetails(apiException, addInner: options.DisplayInnerExceptions);
    }

    internal static string? GetDefaultErrorType(this ApiExceptionBase apiException, ApiExceptionHandlerOptions options)
    {
        if (apiException.ErrorType is not null) return null;

        var useDefaultTypeValue = apiException.GetUseDefaultTypeValue(options);
        if (!useDefaultTypeValue) return null;

        var link = $"{Config.DocumentationLink}/{apiException.StatusCode}";
        return link;
    }

    internal static bool GetUseDefaultTypeValue(this ApiExceptionBase apiException, ApiExceptionHandlerOptions options)
    {
        if (options.DisableDefaultTypeValues) return false;

        var value = apiException.UseDefaultErrorTypeValue;

        if (value is null) return true;

        return value.Value;
    }
}
