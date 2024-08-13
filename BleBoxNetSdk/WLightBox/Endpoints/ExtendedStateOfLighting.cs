using BleBoxNetSdk.Common;
using BleBoxNetSdk.WLightBox.Models;

namespace BleBoxNetSdk.WLightBox.Endpoints;

internal static class ExtendedStateOfLighting
{
    internal class Request() : RequestBase(HttpMethod.Get, "/api/rgbw/extended/state") { }

    internal record ResponseResult
    {
        public RgbwExtended? Rgbw { get; set; }
    }
}
