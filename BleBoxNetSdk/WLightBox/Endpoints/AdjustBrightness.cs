using BleBoxNetSdk.Common;
using BleBoxModels.WLightBox.Enums;
using BleBoxModels.WLightBox.Models;

namespace BleBoxNetSdk.WLightBox.Endpoints;

internal static class AdjustBrightness
{
    internal class Request(Adjust adjust, string channelsDelta)
        : RequestBase(HttpMethod.Get, $"/s/{adjust.ToString().ToLower()}/{channelsDelta}")
    { }

    internal record ResponseResult
    {
        public Rgbw? Rgbw { get; set; }
    }
}
