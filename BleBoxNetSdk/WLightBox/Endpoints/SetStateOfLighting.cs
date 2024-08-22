using BleBoxNetSdk.Common;
using BleBoxModels.WLightBox.Models;

namespace BleBoxNetSdk.WLightBox.Endpoints;

internal static class SetStateOfLighting
{
    internal class Request(
        int effectId,
        string desiredColor,
        uint colorFade,
        uint effectFade,
        uint effectStep) : RequestBase(HttpMethod.Post, "/api/rgbw/set", true)
    {
        public Rgbw? Rgbw { get; set; } = new Rgbw
        {
            EffectID = effectId,
            DesiredColor = desiredColor,
            DurationsMs = new DurationsMs
            {
                ColorFade = colorFade,
                EffectFade = effectFade,
                EffectStep = effectStep
            }
        };
    }

    internal record ResponseResult
    {
        public Rgbw? Rgbw { get; set; }
    }
}
