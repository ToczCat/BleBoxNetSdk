using BleBoxModels.AirSensor.Models;
using BleBoxModels.Common.Models;
using BleBoxNetSdk.Common;
using BleBoxModels.Common.Enums;
using BleBoxModels.AirSensor.Enums;

namespace BleBoxNetSdk.AirSensor.Endpoints;

internal static class SettingsSet
{
    internal class Request(
        string deviceName,
        Toggle tunnelEnabled,
        Toggle tunnelLogEnabled,
        Toggle statusLed,
        Geolocation geolocation,
        Mounting mounting,
        Toggle detailedView) : RequestBase(HttpMethod.Post, "/api/settings/set", true)
    {
        public Settings? Settings { get; set; } = new Settings
        {
            DeviceName = deviceName,
            Tunnel = new Tunnel { Enabled = tunnelEnabled, LogEnabled = tunnelLogEnabled },
            StatusLed = new StatusLed { Enabled = statusLed },
            SensorApi = new SensorApi { MakeGeolocationCoarse = geolocation },
            Air = new AirSettings { DetailedView = detailedView, MountingPlace = mounting }
        };
    }

    internal record ResponseResult
    {
        public Settings? Settings { get; set; }
    }
}
