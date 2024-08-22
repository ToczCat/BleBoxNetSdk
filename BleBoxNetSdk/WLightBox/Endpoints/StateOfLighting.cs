using BleBoxNetSdk.Common;
using BleBoxModels.WLightBox.Models;

namespace BleBoxNetSdk.WLightBox.Endpoints;

internal static class StateOfLighting
{
    internal class Request() : RequestBase(HttpMethod.Get, "/api/rgbw/state") { }

    internal record ResponseResult
    {
        public Rgbw? Rgbw { get; set; }
    }
}
