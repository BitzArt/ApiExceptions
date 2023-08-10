using BitzArt.ApiExceptions;
using OpenTelemetry.Trace;
using System.Diagnostics;

namespace BitzArt;

public static partial class Telemetry
{
    public static void TraceOpenTelemetry()
    {
        ApiException.Events.ApiExceptionThrown += HandleApiExceptionThrown;
    }

    private static void HandleApiExceptionThrown(object sender, ApiExceptionBase exception, EventArgs e)
    {
        Activity.Current.RecordException(exception);
    }
}
