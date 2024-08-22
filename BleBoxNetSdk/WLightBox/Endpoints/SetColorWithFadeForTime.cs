using BleBoxNetSdk.Common;
using BleBoxModels.WLightBox.Models;

namespace BleBoxNetSdk.WLightBox.Endpoints;

internal static class SetColorWithFadeForTime
{
    internal class Request(string channels, uint timeMs, int timeS)
        : RequestBase(HttpMethod.Get, $"/s/{channels}/colorFadeMs/{timeMs}/forTime/{timeS}")
    { }

    internal record ResponseResult
    {
        public Rgbw? Rgbw { get; set; }
    }
}
