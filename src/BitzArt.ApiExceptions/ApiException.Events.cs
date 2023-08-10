using BitzArt.ApiExceptions;

namespace BitzArt;

public static partial class ApiException
{
    private static ApiExceptionEventManager? _eventManager;

    public static ApiExceptionEventManager Events
    {
        get
        {
            _eventManager ??= new ApiExceptionEventManager();
            return _eventManager;
        }
    }

    public class ApiExceptionEventManager
    {
        public delegate void ApiExceptionThrownHandler(object sender, ApiExceptionBase exception, EventArgs e);
        public event ApiExceptionThrownHandler? ApiExceptionThrown;

        internal void RaiseApiExceptionThrown(ApiExceptionBase exception)
        {
            ApiExceptionThrown?.Invoke(this, exception, EventArgs.Empty);
        }
    }
}
