using BleBoxNetSdk.Common.Endpoints;
using BleBoxNetSdk.Services;
using FluentAssertions;

namespace BleBoxNetSdk.Tests.Services;

internal class SerializerTests
{
    [TestCaseSource(nameof(GetTestCases))]
    public void should_deserialize_and_serialize_info<TResponse>(TResponse _, string json)
    {
        var serializer = new Serializer();

        var deserializedObject = serializer.DeserializeJson<TResponse>(json);

        var serializedString = serializer.SerializeJson(deserializedObject);

        serializedString.Should().Be(json);
    }

    private static IEnumerable<TestCaseData> GetTestCases()
    {
        yield return new TestCaseData(new Info.ResponseResult(), Samples.InfoResponse);
        yield return new TestCaseData(new DeviceUptime.ResponseResult(), Samples.UptimeResponse);
        yield return new TestCaseData(new PerformUpdate.ResponseResult(), Samples.PerformUpdateResponse);
        yield return new TestCaseData(new NetworkInformation.ResponseResult(), Samples.NetworkInformationResponse);
        yield return new TestCaseData(new SetNetwork.ResponseResult(), Samples.SetAPResponse);
        yield return new TestCaseData(new WiFiScan.ResponseResult(), Samples.PerformWiFiScanResponse);
        yield return new TestCaseData(new ConnectWiFi.ResponseResult(), Samples.PerformWiFiConnectResponse);
        yield return new TestCaseData(new DisconnectWiFi.ResponseResult(), Samples.PerformWiFiDisconnectResponse);
    }
}
