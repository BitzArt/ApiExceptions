using System.Runtime.ExceptionServices;

namespace BitzArt.ApiExceptions;

public class Tests
{
    [Fact]
    public void ApiException_OnCreate_EventRaised()
    {
        var raised = false;
        AppDomain.CurrentDomain.FirstChanceException += EventHandler;

        void EventHandler(object? sender, FirstChanceExceptionEventArgs e)
            => raised = true;

        var exception1 = new Exception("test exception");

        Assert.False(raised);

        try { throw exception1; }
        catch (Exception) { }

        Assert.True(raised);
    }
}
