using Keys = BitzArt.ApiExceptions.ApiExceptionPayload.Keys;

namespace BitzArt.ApiExceptions;

public partial class ApiExceptionBase
{
    public string? ErrorType
    {
        get => Payload.GetDataEntry<string?>(Keys.ErrorType);
        set => Payload.AddData(Keys.ErrorType, value!);
    }

    public string? Detail
    {
        get => Payload.GetDataEntry<string?>(Keys.Detail);
        set => Payload.AddData(Keys.Detail, value!);
    }

    public string? Instance
    {
        get => Payload.GetDataEntry<string?>(Keys.Instance);
        set => Payload.AddData(Keys.Instance, value!);
    }

    public bool? UseDefaultErrorTypeValue
    {
        get => Payload.GetConfigurationEntry<bool?>(Keys.UseDefaultErrorType);
        set => Payload.AddConfiguration(Keys.UseDefaultErrorType, value!);
    }
}
