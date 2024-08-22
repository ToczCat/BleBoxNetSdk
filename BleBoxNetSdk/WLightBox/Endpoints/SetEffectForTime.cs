using BleBoxNetSdk.Common;
using BleBoxModels.WLightBox.Models;

namespace BleBoxNetSdk.WLightBox.Endpoints;

internal static class SetEffectForTime
{
    internal class Request(int effectId, int timeS)
        : RequestBase(HttpMethod.Get, $"/s/x/{effectId}/forTime/{timeS}")
    { }

    internal record ResponseResult
    {
        public Rgbw? Rgbw { get; set; }
    }
}
