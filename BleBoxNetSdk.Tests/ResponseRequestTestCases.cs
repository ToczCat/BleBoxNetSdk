using BleBoxNetSdk.AirSensor.Endpoints;
using BleBoxModels.AirSensor.Enums;
using BleBoxNetSdk.Common.Endpoints;
using BleBoxModels.Common.Enums;
using BleBoxNetSdk.WLightBox.Endpoints;
using BleBoxModels.WLightBox.Enums;

namespace BleBoxNetSdk.Tests;

public class ResponseRequestTestCases
{
    internal static IEnumerable<TestCaseData> GetResponses()
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
        yield return new TestCaseData(new AirSensor.Endpoints.SettingsState.ResponseResult(), Samples.AirSensorSettingsResponse);
        yield return new TestCaseData(new AirSensor.Endpoints.SettingsSet.ResponseResult(), Samples.AirSensorSetSettingsResponse);

        //WLightBox
        yield return new TestCaseData(new StateOfLighting.ResponseResult(), Samples.WLightBoxStateOfLightingResponse);
        yield return new TestCaseData(new ExtendedStateOfLighting.ResponseResult(), Samples.WLightBoxSetStateOfLightingExtResponse);
        yield return new TestCaseData(new WLightBox.Endpoints.SettingsState.ResponseResult(), Samples.WLightBoxSettingsStateResponse);
    }

    internal static IEnumerable<TestCaseData> GetRequests()
    {
        //Common
        yield return new TestCaseData(new SetNetwork.Request(true, "shutterBox-g650e32d2217", "my_secret_password"), Samples.SetAPRequest);
        yield return new TestCaseData(new ConnectWiFi.Request("WiFi_Name", "my_secret_password"), Samples.PerformWiFiConnectRequest);

        //AirSensor
        yield return new TestCaseData(new AirSensor.Endpoints.SettingsSet.Request(
            "My BleBox device name",
            Toggle.Enabled,
            Toggle.Enabled,
            Toggle.Enabled,
            Geolocation.Accurate,
            Mounting.Outside,
            Toggle.Enabled), Samples.AirSensorSetSettingsRequest);

        //WLightBox
        yield return new TestCaseData(new SetStateOfLighting.Request(
            2,
            "ff003000",
            1000,
            1500,
            2000), Samples.WLightBoxSetStateOfLightingRequest);
        yield return new TestCaseData(new SetExtendedStateOfLighting.Request(
            2,
            "ff003000",
            1000,
            1500,
            2000,
            new Dictionary<string, string>
            {
                {"0", "ff000000" },
                {"1", "00ff0000" },
                {"2", "0000ff00" },
                {"3", "000000ff" },
                {"4", "00000000" },
                {"5", "ff00ff00" },
                {"6", "ffff0000" },
                {"7", "00ffff00" },
                {"8", "ff800000" },
                {"9", "0080ff00" }
            }), Samples.WLightBoxSetStateOfLightingExtRequest);
        yield return new TestCaseData(new WLightBox.Endpoints.SettingsSet.Request(
            "My BleBox device name",
            Toggle.Enabled,
            Toggle.Enabled,
            PwmFrequency.Pwm600,
            ColorMode.Rgbw,
            OutputMode.LinearizedPwm,
            ButtonMode.LastBrightnessWithDimming), Samples.WLightBoxSetSettingsRequest);
    }
}
