using BleBoxNetSdk.AirSensor.Endpoints;
using BleBoxNetSdk.AirSensor.Enums;
using BleBoxNetSdk.Common.Endpoints;
using BleBoxNetSdk.Common.Enums;
using BleBoxNetSdk.Services;
using FluentAssertions;

namespace BleBoxNetSdk.Tests.Services;

internal class SerializerTests
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

    private static IEnumerable<TestCaseData> GetResponses()
    {
        //Common
        yield return new TestCaseData(new Info.ResponseResult(), Samples.InfoResponse);
        yield return new TestCaseData(new DeviceUptime.ResponseResult(), Samples.UptimeResponse);
        yield return new TestCaseData(new PerformUpdate.ResponseResult(), Samples.PerformUpdateResponse);
        yield return new TestCaseData(new NetworkInformation.ResponseResult(), Samples.NetworkInformationResponse);
        yield return new TestCaseData(new SetNetwork.ResponseResult(), Samples.SetAPResponse);
        yield return new TestCaseData(new WiFiScan.ResponseResult(), Samples.PerformWiFiScanResponse);
        yield return new TestCaseData(new ConnectWiFi.ResponseResult(), Samples.PerformWiFiConnectResponse);
        yield return new TestCaseData(new DisconnectWiFi.ResponseResult(), Samples.PerformWiFiDisconnectResponse);

        //AirSensor
        yield return new TestCaseData(new DeviceState.ResponseResult(), Samples.AirSensorDeviceStateResponse);
        yield return new TestCaseData(new ExtendedDeviceState.ResponseResult(), Samples.AirSensorExtendedResponse);
        yield return new TestCaseData(new SensorRuntime.ResponseResult(), Samples.AirSensorRuntimeResponse);
        yield return new TestCaseData(new ForceMeasurement.ResponseResult(), Samples.AirSensorMeasurementResponse);
        yield return new TestCaseData(new SettingsState.ResponseResult(), Samples.AirSensorSettingsResponse);
        yield return new TestCaseData(new SettingsSet.ResponseResult(), Samples.AirSensorSetSettingsResponse);
    }

    private static IEnumerable<TestCaseData> GetRequests()
    {
        //Common
        yield return new TestCaseData(new SetNetwork.Request(true, "shutterBox-g650e32d2217", "my_secret_password"), Samples.SetAPRequest);
        yield return new TestCaseData(new ConnectWiFi.Request("WiFi_Name", "my_secret_password"), Samples.PerformWiFiConnectRequest);

        //AirSensor
        yield return new TestCaseData(new SettingsSet.Request(
            "My BleBox device name",
            Toggle.Enabled,
            Toggle.Enabled,
            Toggle.Enabled,
            Geolocation.Accurate,
            Mounting.Outside,
            Toggle.Enabled), Samples.AirSensorSetSettingsRequest);
    }
}
