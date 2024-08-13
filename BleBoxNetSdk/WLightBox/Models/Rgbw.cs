using BleBoxNetSdk.WLightBox.Enums;

namespace BleBoxNetSdk.WLightBox.Models;

public record Rgbw
{
    public ColorMode? ColorMode { get; set; }
    public int EffectID { get; set; }
    public string? DesiredColor { get; set; }
    public string? CurrentColor { get; set; }
    public string? LastOnColor { get; set; }
    public DurationsMs? DurationsMs { get; set; }
}

public record DurationsMs
{
    public uint ColorFade { get; set; }
    public uint EffectFade { get; set; }
    public uint EffectStep { get; set; }
}