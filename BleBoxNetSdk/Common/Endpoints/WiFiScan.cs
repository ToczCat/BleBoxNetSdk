using BleBoxModels.Common.Models;

namespace BleBoxNetSdk.Common.Endpoints;

internal static class WiFiScan
{
    internal class Request() : RequestBase(HttpMethod.Get, "/api/wifi/scan") { }

    internal record ResponseResult
    {
        public AccessPoint[]? Ap { get; set; }
    }
}
