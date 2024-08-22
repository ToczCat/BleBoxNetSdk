using BleBoxNetSdk.Common;
using BleBoxModels.WLightBox.Models;

namespace BleBoxNetSdk.WLightBox.Endpoints;

internal static class SetColor
{
    internal class Request(string channels)
        : RequestBase(HttpMethod.Get, $"/s/{channels}") { }

    internal record ResponseResult
    {
        public Rgbw? Rgbw { get; set; }
    }
}
