using BleBoxModels.AirSensor.Models;
using BleBoxNetSdk.Common;

namespace BleBoxNetSdk.AirSensor.Endpoints;

internal static class ForceMeasurement
{
    internal class Request() : RequestBase(HttpMethod.Get, "/s/kick") { }

    internal record ResponseResult
    {
        public Air? Air { get; set; }
    }
}
