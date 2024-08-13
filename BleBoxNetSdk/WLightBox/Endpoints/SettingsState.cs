using BleBoxNetSdk.Common;
using BleBoxNetSdk.WLightBox.Models;

namespace BleBoxNetSdk.WLightBox.Endpoints;

internal static class SettingsState
{
    internal class Request() : RequestBase(HttpMethod.Get, $"/api/settings/state")
    { }

    internal record ResponseResult
    {
        public Settings? Settings { get; set; }
    }
}
