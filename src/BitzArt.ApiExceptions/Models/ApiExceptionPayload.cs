namespace BitzArt.ApiExceptions;

public partial class ApiExceptionPayload
{
    public IDictionary<string, object> Data { get; }
    public IDictionary<string, object> Configurations { get; }

    public ApiExceptionPayload(object data) : this()
    {
        AddData(data);
    }

    public ApiExceptionPayload()
    {
        Data = new Dictionary<string, object>();
        Configurations = new Dictionary<string, object>();
    }

    public ApiExceptionPayload(IEnumerable<KeyValuePair<string, object>> data)
    {
        Data = new Dictionary<string, object>(data);
        Configurations = new Dictionary<string, object>();
    }

    public ApiExceptionPayload(IDictionary<string, object> data)
    {
        Data = data;
        Configurations = new Dictionary<string, object>();
    }

    public void AddData(object data)
    {
        var parsed = data.ParseAsExtensions();
        if (parsed is null || !parsed.Any()) return;
        AddData(parsed);
    }

    public void AddConfiguration(object data)
    {
        var parsed = data.ParseAsExtensions();
        if (parsed is null || !parsed.Any()) return;
        AddConfiguration(parsed);
    }

    public void AddData(IEnumerable<KeyValuePair<string, object>> data)
    {
        foreach (var entry in data) AddData(entry);
    }

    public void AddConfiguration(IEnumerable<KeyValuePair<string, object>> data)
    {
        foreach (var entry in data) AddConfiguration(entry);
    }

    public void AddData(KeyValuePair<string, object> entry)
        => AddData(entry.Key, entry.Value);

    public void AddConfiguration(KeyValuePair<string, object> entry)
        => AddConfiguration(entry.Key, entry.Value);

    public void AddData(string key, object value)
        => AddEntry(Data, key, value);

    public void AddConfiguration(string key, object value)
        => AddEntry(Configurations, key, value);

    private void AddEntry(IDictionary<string, object> dict, string key, object value)
    {
        if (value is null) return;
        dict[key] = value;
    }

    public T GetDataEntry<T>(string key)
        => GetEntry<T>(Data, key);

    public T GetConfigurationEntry<T>(string key)
        => GetEntry<T>(Configurations, key);

    private T GetEntry<T>(IDictionary<string, object> dict, string key)
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
