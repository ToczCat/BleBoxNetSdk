using BleBoxModels.Common.Models;

namespace BleBoxNetSdk.Common.Endpoints;

internal static class ConnectWiFi
{
    internal class Request(string? ssid, string? password)
        : RequestBase(HttpMethod.Post, "/api/wifi/connect", true)
    {
        public string? Ssid { get; set; } = ssid;
        public string? Pwd { get; set; } = password;
    }

    internal record ResponseResult : Network
    {
    }
}
