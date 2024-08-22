using BleBoxNetSdk.Common;
using BleBoxModels.WLightBox.Models;

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
