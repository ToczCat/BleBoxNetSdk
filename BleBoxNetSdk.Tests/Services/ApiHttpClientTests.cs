using BleBoxNetSdk.Common.Endpoints;
using BleBoxNetSdk.Services;
using BleBoxNetSdk.Wrappers;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;

namespace BleBoxNetSdk.Tests.Services;

internal class ApiHttpClientTests : ResponseRequestTestCases
{
    [TestCaseSource(nameof(GetResponses))]
    public async Task should_send_request<TResponse>(TResponse _, string json)
    {
        var uri = new Uri("http://127.0.0.1/");
        var request = new PerformUpdate.Request();
        var httpClientMock = new Mock<IHttpClient>();
        var apiHttpClient = PrepareApiHttpClient(httpClientMock.Object);
        var responseMessage = new HttpResponseMessage(System.Net.HttpStatusCode.OK) { Content = new StringContent(json) };
        httpClientMock.Setup(h => h.SendAsync(It.IsAny<HttpRequestMessage>(), CancellationToken.None)).Returns(Task.FromResult(responseMessage));

        var result = await apiHttpClient.Send<TResponse>(uri, request, CancellationToken.None);

        result.Should().NotBeNull();
    }

    [Test]
    public void should_throw_after_failed_trysends()
    {
        var uri = new Uri("http://127.0.0.1/");
        var request = new PerformUpdate.Request();
        var httpClientMock = new Mock<IHttpClient>();
        var apiHttpClient = PrepareApiHttpClient(httpClientMock.Object);
        var responseMessage = new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
        var totalCalls = 3;
        httpClientMock.Setup(h => h.SendAsync(It.IsAny<HttpRequestMessage>(), CancellationToken.None)).Returns(Task.FromResult(responseMessage));

        Assert.ThrowsAsync<Exception>( async () => await apiHttpClient.Send<PerformUpdate.ResponseResult>(uri, request, CancellationToken.None));

        httpClientMock.Verify(m => m.SendAsync(It.IsAny<HttpRequestMessage>(), CancellationToken.None), Times.Exactly(totalCalls));
    }

    private ApiHttpClient PrepareApiHttpClient(IHttpClient? httpClient = null)
    {
        var apiHttpClient = new ApiHttpClient(
            httpClient ?? Mock.Of<IHttpClient>(),
            Mock.Of<ILogger<ApiHttpClient>>(),
            new Serializer());

        return apiHttpClient;
    }
}
