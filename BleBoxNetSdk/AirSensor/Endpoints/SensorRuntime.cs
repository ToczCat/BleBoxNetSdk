using BleBoxModels.AirSensor.Models;
using BleBoxNetSdk.Common;

namespace BleBoxNetSdk.AirSensor.Endpoints;

internal static class SensorRuntime
{
    internal class Request() : RequestBase(HttpMethod.Get, "/api/air/runtime") { }

    internal record ResponseResult
    {
        public Runtime? Runtime { get; set; }
    }
}
