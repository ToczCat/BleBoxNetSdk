using BleBoxNetSdk.Services;
using FluentAssertions;

namespace BleBoxNetSdk.Tests.Services;

internal class SerializerTests : ResponseRequestTestCases
{
    [TestCaseSource(nameof(GetResponses))]
    public void should_deserialize_and_serialize_info<TResponse>(TResponse _, string json)
    {
        var serializer = new Serializer();

        var deserializedObject = serializer.DeserializeJson<TResponse>(json);

        var serializedString = serializer.SerializeJson(deserializedObject);

        serializedString.Should().Be(json);
    }

    [TestCaseSource(nameof(GetRequests))]
    public void should_serialize_requests(object request, string json)
    {
        var serializer = new Serializer();

        var serializedString = serializer.SerializeJson(request);

        serializedString.Should().Be(json);
    }
}
