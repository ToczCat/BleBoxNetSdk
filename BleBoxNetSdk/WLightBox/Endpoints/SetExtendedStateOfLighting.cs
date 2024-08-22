using BleBoxNetSdk.Common;
using BleBoxModels.WLightBox.Models;

namespace BleBoxNetSdk.WLightBox.Endpoints;

internal static class SetExtendedStateOfLighting
{
    internal class Request(
    int effectId,
    string desiredColor,
    uint colorFade,
    uint effectFade,
    uint effectStep,
    Dictionary<string, string> favColors) : RequestBase(HttpMethod.Post, "/api/rgbw/extended/set", true)
    {
        public RgbwExtended? Rgbw { get; set; } = new RgbwExtended
        {
            EffectID = effectId,
            DesiredColor = desiredColor,
            DurationsMs = new DurationsMs
            {
                ColorFade = colorFade,
                EffectFade = effectFade,
                EffectStep = effectStep
            },
            FavColors = favColors
        };
    }

    internal record ResponseResult
    {
        public RgbwExtended? Rgbw { get; set; }
    }
}
