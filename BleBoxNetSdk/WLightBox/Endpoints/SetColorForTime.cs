using BleBoxNetSdk.Common;
using BleBoxModels.WLightBox.Models;

namespace BleBoxNetSdk.WLightBox.Endpoints;

internal static class SetColorForTime
{
    internal class Request(string channels, int timeS)
        : RequestBase(HttpMethod.Get, $"/s/{channels}/forTime/{timeS}")
    { }

    internal record ResponseResult
    {
        public Rgbw? Rgbw { get; set; }
    }
}
