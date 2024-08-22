using BleBoxModels.AirSensor.Models;
using BleBoxNetSdk.Common;

namespace BleBoxNetSdk.AirSensor.Endpoints;

internal static class DeviceState
{
    internal class Request() : RequestBase(HttpMethod.Get, "/state") {}

    internal record ResponseResult
    {
        public Air? Air { get; set; }
    }
}
