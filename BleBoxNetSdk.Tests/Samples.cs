namespace BleBoxNetSdk.Tests;

internal static class Samples
{
    //CommonAPI
    public static string InfoResponse = """{"device":{"deviceName":"My BleBox device name","product":"shutterBoxV2","type":"shutterBox","apiLevel":"20200831","hv":"9.1d","fv":"0.987","id":"g650e32d2217","ip":"192.168.1.11"}}""";
    public static string UptimeResponse = """{"upTimeS":243269}""";
    public static string PerformUpdateResponse = """{}""";
    public static string NetworkInformationResponse = """{"ssid":"WiFi_Name","bssid":"70:4f:25:24:11:ae","ip":"192.168.1.11","mac":"bb:50:ec:2d:22:17","station_status":5,"tunnel_status":5,"apEnable":true,"apSSID":"shutterBox-g650e32d2217","apPasswd":"my_secret_password","channel":7}""";
    public static string SetAPRequest = """{"network":{"apEnable":true,"apSSID":"shutterBox-g650e32d2217","apPasswd":"my_secret_password"}}""";
    public static string SetAPResponse = """{"device":{"deviceName":"My BleBox device name","product":"shutterBoxV2","type":"shutterBox","apiLevel":"20200831","hv":"9.1d","fv":"0.987","id":"g650e32d2217","ip":"192.168.1.11"},"network":{"ssid":"WiFi_Name","bssid":"70:4f:25:24:11:ae","ip":"192.168.1.11","mac":"bb:50:ec:2d:22:17","station_status":5,"tunnel_status":5,"apEnable":true,"apSSID":"shutterBox-g650e32d2217","apPasswd":"my_secret_password","channel":7}}""";
    public static string PerformWiFiScanResponse = """{"ap":[{"ssid":"Funny_WiFi_Name","rssi":-60,"enc":3},{"ssid":"Less_Funny_WiFi_Name","rssi":-75,"enc":4},{"ssid":"Not_Funny_WiFi_Name","rssi":-90,"enc":0}]}""";
    public static string PerformWiFiConnectRequest = """{"ssid":"WiFi_Name","pwd":"my_secret_password"}""";
    public static string PerformWiFiConnectResponse = """{"ssid":"WiFi_Name","station_status":5,"tunnel_status":0,"apEnable":false,"channel":0}""";
    public static string PerformWiFiDisconnectResponse = """{"ssid":"WiFi_Name","station_status":5,"tunnel_status":0,"apEnable":false,"channel":0}""";

    //AirSensor
    public static string AirSensorDeviceStateResponse = """{"air":{"airQualityLevel":2,"sensors":[{"type":"pm1","value":9,"qualityLevel":-1,"trend":3,"state":0,"elapsedTimeS":15},{"type":"pm2.5","value":14,"qualityLevel":2,"trend":3,"state":0,"elapsedTimeS":15},{"type":"pm10","value":15,"qualityLevel":1,"trend":3,"state":0,"elapsedTimeS":15}]}}""";
    public static string AirSensorExtendedResponse = """{"air":{"airQualityLevel":2,"sensors":[{"type":"pm1","value":9,"qualityLevel":-1,"trend":3,"state":0,"elapsedTimeS":15},{"type":"pm2.5","value":14,"qualityLevel":2,"trend":3,"state":0,"elapsedTimeS":15},{"type":"pm10","value":15,"qualityLevel":1,"trend":3,"state":0,"elapsedTimeS":15}]}}""";
    public static string AirSensorRuntimeResponse = """{"runtime":{"timeH":1}}""";
    public static string AirSensorMeasurementResponse = """{"air":{"airQualityLevel":2,"sensors":[{"type":"pm1","value":9,"qualityLevel":-1,"trend":3,"state":0,"elapsedTimeS":15},{"type":"pm2.5","value":14,"qualityLevel":2,"trend":3,"state":0,"elapsedTimeS":15},{"type":"pm10","value":15,"qualityLevel":1,"trend":3,"state":0,"elapsedTimeS":15}]}}""";
    public static string AirSensorSettingsResponse = """{"settings":{"sensorApi":{"makeGeolocationCoarse":0},"air":{"mountingPlace":0,"detailedView":1},"deviceName":"My BleBox device name","tunnel":{"enabled":1,"logEnabled":1},"statusLed":{"enabled":1}}}""";
    public static string AirSensorSetSettingsRequest = """{"settings":{"sensorApi":{"makeGeolocationCoarse":0},"air":{"mountingPlace":0,"detailedView":1},"deviceName":"My BleBox device name","tunnel":{"enabled":1,"logEnabled":1},"statusLed":{"enabled":1}}}""";
    public static string AirSensorSetSettingsResponse = """{"settings":{"sensorApi":{"makeGeolocationCoarse":0},"air":{"mountingPlace":0,"detailedView":1},"deviceName":"My BleBox device name","tunnel":{"enabled":1,"logEnabled":1},"statusLed":{"enabled":1}}}""";

    //WLightBox
    public static string WLightBoxStateOfLightingResponse = """{"rgbw":{"colorMode":1,"effectID":2,"desiredColor":"ff003000","currentColor":"ff003000","lastOnColor":"ff003000","durationsMs":{"colorFade":1000,"effectFade":1500,"effectStep":2000}}}""";
    public static string WLightBoxSetStateOfLightingRequest = """{"rgbw":{"effectID":2,"desiredColor":"ff003000","durationsMs":{"colorFade":1000,"effectFade":1500,"effectStep":2000}}}""";
    public static string WLightBoxSetStateOfLightingExtResponse = """{"rgbw":{"effectNames":{"0":"NONE","1":"FADE","2":"RGB","3":"POLICE","4":"RELAX","5":"STROBO","6":"BELL"},"favColors":{"0":"ff000000","1":"00ff0000","2":"0000ff00","3":"000000ff","4":"00000000","5":"ff00ff00","6":"ffff0000","7":"00ffff00","8":"ff800000","9":"0080ff00"},"colorMode":1,"effectID":2,"desiredColor":"ff003000","currentColor":"ff003000","lastOnColor":"ff003000","durationsMs":{"colorFade":1000,"effectFade":1500,"effectStep":2000}}}""";
    public static string WLightBoxSetStateOfLightingExtRequest = """{"rgbw":{"favColors":{"0":"ff000000","1":"00ff0000","2":"0000ff00","3":"000000ff","4":"00000000","5":"ff00ff00","6":"ffff0000","7":"00ffff00","8":"ff800000","9":"0080ff00"},"effectID":2,"desiredColor":"ff003000","durationsMs":{"colorFade":1000,"effectFade":1500,"effectStep":2000}}}""";
    public static string WLightBoxSettingsStateResponse = """{"settings":{"rgbw":{"colorMode":1,"outputMode":1,"pwmFreq":600,"buttonMode":4,"fieldsPreferences":[{"name":"buttonMode","values":[0,1,2,3,4]},{"name":"colorMode","values":[1,2,3,4,5,6]},{"name":"outputMode","values":[1,2,3,4]},{"name":"pwmFreq","values":[486,600,1200]}]},"deviceName":"My BleBox device name","tunnel":{"enabled":1,"logEnabled":0},"statusLed":{"enabled":1}}}""";
    public static string WLightBoxSetSettingsRequest = """{"settings":{"rgbw":{"colorMode":1,"outputMode":1,"pwmFreq":600,"buttonMode":4},"deviceName":"My BleBox device name","tunnel":{"enabled":1},"statusLed":{"enabled":1}}}""";
}
