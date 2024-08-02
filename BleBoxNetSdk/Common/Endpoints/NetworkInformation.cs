using BleBoxNetSdk.Common.Models;

namespace BleBoxNetSdk.Common.Endpoints;

internal static class NetworkInformation
{
    internal class Request() : RequestBase(HttpMethod.Get, "/api/device/network") { }

    internal record ResponseResult : Network
    {
    }
}