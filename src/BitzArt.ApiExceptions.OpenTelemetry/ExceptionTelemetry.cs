using OpenTelemetry.Trace;
using System.Diagnostics;
using System.Runtime.ExceptionServices;

namespace BitzArt;

public static partial class ExceptionTelemetry
{
    public static void EnableOpenTelemetry()
    {
        AppDomain.CurrentDomain.FirstChanceException += RecordExceptionThrown;
    }

    private static void RecordExceptionThrown(object? sender, FirstChanceExceptionEventArgs e)
    {
        Activity.Current.RecordException(e.Exception);
    }
}
