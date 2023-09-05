using BitzArt.ApiExceptions;
using BitzArt.ApiExceptions.AspNetCore;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace System;

internal static class ExceptionExtensions
{
    internal static int GetHttpStatusCode(this Exception exception)
    {
        if (exception is ApiExceptionBase apiException) return apiException.StatusCode;
        return (int)HttpStatusCode.InternalServerError;
    }

    internal static ProblemDetails GetProblemDetails(this Exception exception, HttpContext httpContext, ApiExceptionHandlerOptions options)
    {
        if (exception is ApiExceptionBase apiException) return apiException.GetProblemDetails(httpContext, options);

        httpContext.Response.ContentType = "application/problem+json";
        httpContext.Response.StatusCode = 500;
        return new ProblemDetails(exception, addInner: options.AddInnerExceptions);
    }
}
