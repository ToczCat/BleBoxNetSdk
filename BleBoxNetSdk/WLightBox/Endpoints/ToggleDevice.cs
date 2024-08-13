using BleBoxNetSdk.Common;
using BleBoxNetSdk.WLightBox.Models;

namespace BleBoxNetSdk.WLightBox.Endpoints;

internal static class ToggleDevice
{
    internal class Request() : RequestBase(HttpMethod.Get, "/s/offon/last") { }

    internal record ResponseResult
    {
        public Rgbw? Rgbw { get; set; }
    }
}
