using BleBoxNetSdk.Common;
using BleBoxNetSdk.WLightBox.Models;

namespace BleBoxNetSdk.WLightBox.Endpoints;

internal static class SetEffect
{
    internal class Request(int effectId)
        : RequestBase(HttpMethod.Get, $"/s/x/{effectId}")
    { }

    internal record ResponseResult
    {
        public Rgbw? Rgbw { get; set; }
    }
}
