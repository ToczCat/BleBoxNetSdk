using BleBoxModels.AirSensor.Models;
using BleBoxNetSdk.Common;

namespace BleBoxNetSdk.AirSensor.Endpoints;

internal static class SettingsState
{
    internal class Request() : RequestBase(HttpMethod.Get, "/api/settings/state") { }

    internal record ResponseResult
    {
        public Settings? Settings { get; set; }
    }
}
