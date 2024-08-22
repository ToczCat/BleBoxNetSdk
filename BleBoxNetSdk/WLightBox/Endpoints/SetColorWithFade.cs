using BleBoxNetSdk.Common;
using BleBoxModels.WLightBox.Models;

namespace BleBoxNetSdk.WLightBox.Endpoints;

internal static class SetColorWithFade
{
    internal class Request(string channels, uint timeMs)
        : RequestBase(HttpMethod.Get, $"/s/{channels}/colorFadeMs/{timeMs}")
    { }

    internal record ResponseResult
    {
        public Rgbw? Rgbw { get; set; }
    }
}
