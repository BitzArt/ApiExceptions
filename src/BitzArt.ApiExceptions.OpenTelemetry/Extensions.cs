using BitzArt.ApiExceptions;
using OpenTelemetry.Trace;
using System.Diagnostics;

namespace BitzArt;

public static partial class ApiExceptionTelemetry
{
    public static void EnableOpenTelemetry()
    {
        ApiException.Events.ApiExceptionThrown += HandleApiExceptionThrown;
    }

    private static void HandleApiExceptionThrown(object sender, ApiExceptionBase exception, EventArgs e)
    {
        Activity.Current.RecordException(exception);
    }
}
