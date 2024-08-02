using System.Text.Json.Serialization;
using System.Text.Json;
using BleBoxNetSdk.Common.JsonConverters;

namespace BleBoxNetSdk.Services;

public interface ISerializer
{
    TResult? DeserializeJson<TResult>(string jsonResult);
    string SerializeJson(object? content);
}

internal class Serializer : ISerializer
{
    private JsonSerializerOptions _jsonOptions;

    internal Serializer()
    {
        _jsonOptions = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            Converters = { new IntSecondsToTimeSpanConverter() }
        };
    }

    public string SerializeJson(object? content)
    {
        return JsonSerializer.Serialize(content, _jsonOptions);
    }

    public TResult? DeserializeJson<TResult>(string jsonResult)
    {
        if (string.IsNullOrEmpty(jsonResult))
            jsonResult = "{}";

        return JsonSerializer.Deserialize<TResult>(jsonResult, _jsonOptions);
    }
}
