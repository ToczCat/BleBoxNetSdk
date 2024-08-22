using BleBoxNetSdk.Common;
using BleBoxModels.WLightBox.Models;

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
