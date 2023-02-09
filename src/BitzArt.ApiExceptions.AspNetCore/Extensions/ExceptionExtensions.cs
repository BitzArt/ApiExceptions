using BitzArt.ApiExceptions;
using System.Net;

namespace System;

public static class ExceptionExtensions
{
    public static int GetHttpStatusCode(this Exception exception)
    {
        if (exception is ApiExceptionBase apiException) return apiException.StatusCode;
        return (int)HttpStatusCode.InternalServerError;
    }
}
