using BleBoxNetSdk.Common;
using BleBoxNetSdk.WLightBox.Models;

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
