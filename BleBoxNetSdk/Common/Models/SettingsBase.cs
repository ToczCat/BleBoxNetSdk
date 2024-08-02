using BleBoxNetSdk.Common.Enums;

namespace BleBoxNetSdk.Common.Models;

public record SettingsBase
{
    public string? DeviceName { get; set; }
    public Tunnel? Tunnel { get; set; }
    public StatusLed? StatusLed { get; set; }
}

public record StatusLed
{
    public Enabled Enabled { get; set; }
}

public record Tunnel
{
    public Enabled Enabled { get; set; }
    public Enabled LogEnabled { get; set; }
}