using System.Text.Json.Serialization;

namespace BleBoxNetSdk.Common;

public interface IRequest
{
    HttpMethod HttpMethod { get; }
    string Uri { get; }
    bool HaveContent { get; }
}

internal abstract class RequestBase : IRequest
{
    internal RequestBase(HttpMethod method, string uri, bool haveContent = false)
    {
        HttpMethod = method;
        Uri = uri;
        HaveContent = haveContent;
    }

    [JsonIgnore]
    public HttpMethod HttpMethod { get; }

    [JsonIgnore]
    public string Uri { get; }

    [JsonIgnore]
    public bool HaveContent { get; }
}
