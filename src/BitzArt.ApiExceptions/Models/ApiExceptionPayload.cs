namespace BitzArt.ApiExceptions;

/// <summary>
/// API Exception Payload, used to add additional data to the exception.
/// </summary>
public partial class ApiExceptionPayload
{
    /// <summary>
    /// Registered keys for a ProblemDetails payload.
    /// </summary>
    public static class Keys
    {
        /// <summary>
        /// ProblemDetails.Title
        /// </summary>
        public const string Title = "title";
        /// <summary>
        /// ProblemDetails.Status
        /// </summary>
        public const string Status = "status";
        /// <summary>
        /// ProblemDetails.ErrorType
        /// </summary>
        public const string ErrorType = "type";
        /// <summary>
        /// ProblemDetails.Detail
        /// </summary>
        public const string Detail = "detail";
        /// <summary>
        /// ProblemDetails.Instance
        /// </summary>
        public const string Instance = "instance";
        /// <summary>
        /// UseDefaultErrorType
        /// </summary>
        public const string UseDefaultErrorType = "useDefaultType";
    }

    /// <summary>
    /// Custom data for the error response.
    /// </summary>
    public IDictionary<string, object> Data { get; }

    /// <summary>
    /// Custom configurations for the error response creation.
    /// </summary>
    public IDictionary<string, object> Configurations { get; }

    /// <summary>
    /// Creates a new instance of <see cref="ApiExceptionPayload"/>.
    /// </summary>
    /// <param name="data"></param>
    public ApiExceptionPayload(object data) : this()
    {
        AddData(data);
    }

    /// <summary>
    /// Creates a new instance of <see cref="ApiExceptionPayload"/>.
    /// </summary>
    public ApiExceptionPayload()
    {
        Data = new Dictionary<string, object>();
        Configurations = new Dictionary<string, object>();
    }

    /// <summary>
    /// Creates a new instance of <see cref="ApiExceptionPayload"/>.
    /// </summary>
    /// <param name="data"></param>
    public ApiExceptionPayload(IEnumerable<KeyValuePair<string, object>> data)
    {
        Data = new Dictionary<string, object>(data);
        Configurations = new Dictionary<string, object>();
    }

    /// <summary>
    /// Creates a new instance of <see cref="ApiExceptionPayload"/>.
    /// </summary>
    /// <param name="data"></param>
    public ApiExceptionPayload(IDictionary<string, object> data)
    {
        Data = data;
        Configurations = new Dictionary<string, object>();
    }

    /// <summary>
    /// Adds custom data to the payload.
    /// </summary>
    /// <param name="data"></param>
    public void AddData(object data)
    {
        var parsed = data.ParseAsExtensions();
        if (parsed is null || !parsed.Any()) return;
        AddData(parsed);
    }

    /// <summary>
    /// Adds custom configurations to the payload.
    /// </summary>
    /// <param name="data"></param>
    public void AddConfiguration(object data)
    {
        var parsed = data.ParseAsExtensions();
        if (parsed is null || !parsed.Any()) return;
        AddConfiguration(parsed);
    }

    /// <summary>
    /// Adds custom data to the payload.
    /// </summary>
    /// <param name="data"></param>
    public void AddData(IEnumerable<KeyValuePair<string, object>> data)
    {
        foreach (var entry in data) AddData(entry);
    }

    /// <summary>
    /// Adds custom configurations to the payload.
    /// </summary>
    /// <param name="data"></param>
    public void AddConfiguration(IEnumerable<KeyValuePair<string, object>> data)
    {
        foreach (var entry in data) AddConfiguration(entry);
    }

    /// <summary>
    /// Adds custom data to the payload.
    /// </summary>
    /// <param name="entry"></param>
    public void AddData(KeyValuePair<string, object> entry)
        => AddData(entry.Key, entry.Value);

    /// <summary>
    /// Adds custom configurations to the payload.
    /// </summary>
    /// <param name="entry"></param>
    public void AddConfiguration(KeyValuePair<string, object> entry)
        => AddConfiguration(entry.Key, entry.Value);

    /// <summary>
    /// Adds custom data to the payload.
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public void AddData(string key, object value)
        => AddEntry(Data, key, value);

    /// <summary>
    /// Adds custom configurations to the payload.
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public void AddConfiguration(string key, object value)
        => AddEntry(Configurations, key, value);

    private static void AddEntry(IDictionary<string, object> dict, string key, object value)
    {
        if (value is null) return;
        dict[key] = value;
    }

    /// <summary>
    /// Retrieves custom data from the payload.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <returns></returns>
    public T GetDataEntry<T>(string key)
        => GetEntry<T>(Data, key);

    /// <summary>
    /// Retrieves custom configurations from the payload.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <returns></returns>
    public T GetConfigurationEntry<T>(string key)
        => GetEntry<T>(Configurations, key);

    private static T GetEntry<T>(IDictionary<string, object> dict, string key)
    {
        if (!dict.ContainsKey(key)) return default!;

        var value = dict
            .Where(x => x.Key == key)
            .Single()
            .Value;

        if (value is not T) throw new Exception($"'{key}' is not a {typeof(T).Name}");

        return (T)value;
    }
}
