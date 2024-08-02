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
}
