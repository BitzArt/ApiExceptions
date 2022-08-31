namespace BitzArt.ApiExceptions;

public partial class ApiExceptionPayload
{
    public IDictionary<string, object> Data { get; }

    public ApiExceptionPayload()
    {
        Data = new Dictionary<string, object>();
    }

    public ApiExceptionPayload(IEnumerable<KeyValuePair<string, object>> data)
    {
        Data = new Dictionary<string, object>(data);
    }

    public ApiExceptionPayload(IDictionary<string, object> data)
    {
        Data = data;
    }

    public ApiExceptionPayload(object data) : this()
    {
        Add(data);
    }

    public void Add(object extensions)
    {
        var parsed = extensions.ParseAsExtensions();
        if (parsed is null || !parsed.Any()) return;
        Add(parsed);
    }

    public void Add(IEnumerable<KeyValuePair<string, object>> extensions)
    {
        foreach (var extension in extensions) Add(extension);
    }

    public void Add(KeyValuePair<string, object> extension)
    {
        Add(extension.Key, extension.Value);
    }

    public void Add(string key, object value)
    {
        if (value is null) return;
        Data[key] = value;
    }

    public T Get<T>(string key)
    {
        if (!Data.ContainsKey(key)) return default!;

        var value = Data
            .Where(x => x.Key == key)
            .Single()
            .Value;

        if (value is not T) throw new Exception($"'{key}' is not a {typeof(T).Name}");

        return (T)value;
    }
}
