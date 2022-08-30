namespace BitzArt.ApiExceptions;

public abstract class ApiExceptionBase : Exception
{
    public int StatusCode { get; set; }

    public IDictionary<string, object> Extensions { get; }

    protected ApiExceptionBase
        (string message = "Unexpected Error", ApiStatusCode statusCode = ApiStatusCode.Error, IDictionary<string, object>? extensions = null)
        : this(message, (int)statusCode, extensions)
    { }

    protected ApiExceptionBase
        (string message, int statusCode, IDictionary<string, object>? extensions = null)
        : base(message)
    {
        StatusCode = statusCode;
        Extensions = extensions ?? new Dictionary<string, object>();
    }

    public void AddExtensions(object extensions)
    {
        var parsed = extensions.ParseAsExtensions();
        if (parsed is null || !parsed.Any()) return;
        AddExtensions(parsed);
    }

    public void AddExtensions(IEnumerable<KeyValuePair<string, object>> extensions)
    {
        foreach (var extension in extensions) AddExtensions(extension);
    }

    public void AddExtensions(KeyValuePair<string, object> extension)
    {
        AddExtensions(extension.Key, extension.Value);
    }

    public void AddExtensions(string key, object value)
    {
        Extensions[key] = value;
    }

    public T GetExtension<T>(string key)
    {
        if (!Extensions.ContainsKey(key)) return default!;

        var value = Extensions
            .Where(x => x.Key == key)
            .Single()
            .Value;

        if (value is not T) throw new Exception($"'{key}' is not a {typeof(T).Name}");

        return (T)value;
    }
}
