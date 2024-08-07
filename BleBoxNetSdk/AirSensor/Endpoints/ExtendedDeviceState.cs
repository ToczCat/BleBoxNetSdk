using BleBoxNetSdk.AirSensor.Models;
using BleBoxNetSdk.Common;

namespace BleBoxNetSdk.AirSensor.Endpoints;

internal static class ExtendedDeviceState
{
    internal class Request() : RequestBase(HttpMethod.Get, "/state/extended") { }

    internal record ResponseResult
    {
        public Air? Air { get; set; }
    }
}
