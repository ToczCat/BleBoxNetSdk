using BleBoxNetSdk.Common;
using BleBoxNetSdk.Wrappers;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text;
using System.Text.Json;

namespace BleBoxNetSdk.Services;

public interface IApiHttpClient
{
    Task<TResult> Send<TResult>(Uri baseUri, IRequest requestObject, CancellationToken cancellationToken);
}

public class ApiHttpClient(IHttpClient httpClient, ILogger<ApiHttpClient> logger, ISerializer serializer) : IApiHttpClient
{
    private const int MaxResendCount = 3;
    private const string JsonContentType = "application/json";

    private readonly Encoding _encoding = Encoding.UTF8;

    public async Task<TResult> Send<TResult>(
        Uri baseUri,
        IRequest requestObject,
        CancellationToken cancellationToken)
    {
        var response = await TrySend(baseUri, requestObject, cancellationToken);

        var serializedResult = await response.Content.ReadAsStringAsync(cancellationToken);
        logger.LogDebug("<- Received response: {response}", serializedResult);

        var deserializedResult = serializer.DeserializeJson<TResult>(serializedResult)
            ?? throw new JsonException($"Could not deserialize {serializedResult} to {typeof(TResult)}");

        return deserializedResult;
    }

    private async Task<HttpResponseMessage> TrySend(
        Uri baseUri,
        IRequest requestObject,
        CancellationToken cancellationToken)
    {
        for (int count = 1; count <= MaxResendCount; count++)
        {
            try
            {
                var request = PrepareRequest(baseUri, requestObject);

                var response = await httpClient.SendAsync(request, cancellationToken);

                if (response.StatusCode == HttpStatusCode.Conflict)
                    logger.LogWarning("Requested action is already in progress");

                response.EnsureSuccessStatusCode();

                return response;
            }
            catch (Exception ex) when (count <= MaxResendCount)
            {
                await Task.Delay(TimeSpan.FromSeconds(3), cancellationToken);

                logger.LogWarning("Request to API failed with exception: {ex}. Resending request {count}", ex, count);
            }
        }

        throw new Exception($"Request to API {requestObject.Uri} failed");
    }

    private HttpRequestMessage PrepareRequest(
        Uri baseUri,
        IRequest requestObject)
    {
        var request = new HttpRequestMessage(requestObject.HttpMethod, BuildUri(baseUri, requestObject.Uri));
        logger.LogDebug("-> Sending http request to: {uri}", request.RequestUri?.ToString());

        if (requestObject.HaveContent)
        {
            var serializedContent = serializer.SerializeJson(requestObject);

            logger.LogDebug("-> With body: {body}", serializedContent);
            request.Content = new StringContent(serializedContent, _encoding, JsonContentType);
        }

        return request;
    }

    private Uri BuildUri(Uri baseUri, string endpoint)
    {
        var builder = new UriBuilder(baseUri);

        builder.Path = builder.Path.TrimEnd('/') + endpoint;

        return builder.Uri;
    }
}
