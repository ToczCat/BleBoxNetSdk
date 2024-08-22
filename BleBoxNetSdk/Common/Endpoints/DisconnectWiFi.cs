using BleBoxModels.Common.Models;

namespace BleBoxNetSdk.Common.Endpoints;

internal static class DisconnectWiFi
{
    internal class Request() : RequestBase(HttpMethod.Post, "/api/wifi/disconnect") { }

    internal record ResponseResult : Network { }
}
    