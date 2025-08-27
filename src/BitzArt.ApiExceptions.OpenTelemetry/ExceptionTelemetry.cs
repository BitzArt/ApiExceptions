using OpenTelemetry.Trace;
using System.Diagnostics;
using System.Runtime.ExceptionServices;

namespace BitzArt;

/// <summary>
/// Contains additional functionality for reporting ApiExceptions to OpenTelemetry.
/// </summary>
public static partial class ExceptionTelemetry
{
    /// <summary>
    /// This method will enable reporting of all exceptions that were raised
    /// in your application to OpenTelemetry.
    /// </summary>
    public static void EnableOpenTelemetry()
    {
        AppDomain.CurrentDomain.FirstChanceException += RecordExceptionThrown;
    }

    private static void RecordExceptionThrown(object? sender, FirstChanceExceptionEventArgs e)
    {
        var activity = Activity.Current;
        var ex = e.Exception;

        if (activity is null || e is null) return;

        if (!activity!.Events.Any(x => x.Name == "exception" &&
            x.Tags.Any(xx =>
                xx.Key == "exception.message"
                && (string)xx.Value! == ex.Message)))
        {
            activity.RecordException(ex);
        }
    }
}
