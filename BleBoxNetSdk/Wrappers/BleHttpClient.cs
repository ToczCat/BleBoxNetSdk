namespace BleBoxNetSdk.Wrappers;

public interface IHttpClient
{
    Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken token = default);
}

public class BleHttpClient : IHttpClient
{
    private readonly HttpClient _httpClient;

    public BleHttpClient()
    {
        _httpClient = new HttpClient();
    }

    public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken token = default)
        => _httpClient.SendAsync(request, token);
}
