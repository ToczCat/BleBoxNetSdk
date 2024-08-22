using BleBoxModels.Common.Enums;
using BleBoxModels.Common.Models;
using BleBoxNetSdk.Common;
using BleBoxModels.WLightBox.Models;
using BleBoxModels.WLightBox.Enums;

namespace BleBoxNetSdk.WLightBox.Endpoints;

internal static class SettingsSet
{
    internal class Request(
        string deviceName,
        Toggle tunnelEnabled,
        Toggle statusLed,
        PwmFrequency pwmFrequency,
        ColorMode? colorMode = null,
        OutputMode? outputMode = null,
        ButtonMode? buttonMode = null) : RequestBase(HttpMethod.Post, "/api/settings/set", true)
    {
        public Settings? Settings { get; set; } = new Settings
        {
            DeviceName = deviceName,
            Tunnel = new Tunnel { Enabled = tunnelEnabled },
            StatusLed = new StatusLed { Enabled = statusLed },
            Rgbw = new RgbwSet
            {
                PwmFreq = pwmFrequency,
                ColorMode = colorMode,
                OutputMode = outputMode,
                ButtonMode = buttonMode
            }
        };
    }

    internal record ResponseResult
    {
        public Settings? Settings { get; set; }
    }
}
