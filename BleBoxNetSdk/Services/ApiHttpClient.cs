﻿using BleBoxNetSdk.Common;
using Microsoft.Extensions.Logging;
using System.Text;
using System.Text.Json;

namespace BleBoxNetSdk.Services;

public interface IApiHttpClient
{
    Task<TResult> Send<TResult>(Uri baseUri, IRequest requestObject, CancellationToken cancellationToken);
}

internal class ApiHttpClient : IApiHttpClient
{
    private const int MaxResendCount = 3;
    private const string JsonContentType = "application/json";

    private readonly HttpClient _httpClient;
    private readonly ILogger<ApiHttpClient> _logger;
    private readonly ISerializer _serializer;
    private readonly Encoding _encoding = Encoding.UTF8;

    internal ApiHttpClient(
        ILogger<ApiHttpClient> logger,
        ISerializer serializer)
    {
        _httpClient = new HttpClient();
        _logger = logger;
        _serializer = serializer;
    }

    public async Task<TResult> Send<TResult>(
        Uri baseUri,
        IRequest requestObject,
        CancellationToken cancellationToken)
    {
        var response = await Send(baseUri, requestObject, cancellationToken);

        var serializedResult = await response.Content.ReadAsStringAsync();

        _logger.LogDebug("<- Received response: {response}", serializedResult);

        var deserializedResult = _serializer.DeserializeJson<TResult>(serializedResult)
            ?? throw new JsonException($"Could not deserialize {serializedResult} to {typeof(TResult)}");

        return deserializedResult;
    }

    private async Task<HttpResponseMessage> Send(
        Uri baseUri,
        IRequest requestObject,
        CancellationToken cancellationToken)
    {
        for (int count = 1; count <= MaxResendCount; count++)
        {
            try
            {
                var request = PrepareRequest(baseUri, requestObject);

                var response = await _httpClient.SendAsync(request, cancellationToken);

                response.EnsureSuccessStatusCode();

                return response;
            }
            catch (Exception ex) when (count < MaxResendCount)
            {
                await Task.Delay(TimeSpan.FromSeconds(3));

                _logger.LogWarning("Request to API failed with exception: {ex}. Resending request {count}", ex, count);
            }
        }

        throw new Exception($"Request to API {requestObject.Uri} failed");
    }

    private HttpRequestMessage PrepareRequest(
        Uri baseUri,
        IRequest requestObject)
    {
        var request = new HttpRequestMessage(requestObject.HttpMethod, BuildUri(baseUri, requestObject.Uri));

        _logger.LogDebug("-> Sending http request to: {uri}", request.RequestUri?.ToString());

        if (requestObject.HaveContent)
        {
            var serializedContent = _serializer.SerializeJson(requestObject);


            _logger.LogDebug("-> With body: {body}", serializedContent);
            request.Content = new StringContent(serializedContent, _encoding, JsonContentType);
        }

        return request;
    }

    private Uri BuildUri(Uri baseUri, string endpoint)
    {
        var builder = new UriBuilder(baseUri);

        builder.Path.TrimEnd('/');
        builder.Path += endpoint;

        return builder.Uri;
    }
}