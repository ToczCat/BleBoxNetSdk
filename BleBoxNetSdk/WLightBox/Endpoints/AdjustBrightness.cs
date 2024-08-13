﻿using BleBoxNetSdk.Common;
using BleBoxNetSdk.WLightBox.Enums;
using BleBoxNetSdk.WLightBox.Models;

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