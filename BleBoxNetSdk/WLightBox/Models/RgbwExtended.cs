namespace BleBoxNetSdk.WLightBox.Models;

public record RgbwExtended : Rgbw
{
    public Dictionary<string, string>? EffectNames { get; set; }
    public Dictionary<string, string>? FavColors { get; set; }
}
