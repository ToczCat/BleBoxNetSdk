using BleBoxNetSdk.Common;
using BleBoxModels.WLightBox.Models;

namespace BleBoxNetSdk.WLightBox.Endpoints;

internal static class SetLastState
{
    internal class Request() : RequestBase(HttpMethod.Get, "/s/onlast") { }

    internal record ResponseResult
    {
        public Rgbw? Rgbw { get; set; }
    }
}
