using BleBoxNetSdk.Common.Enums;

namespace BleBoxNetSdk.Common.Models;

public record AccessPoint
{
    public string? Ssid { get; set; }
    public int Rssi { get; set; }
    public EncryptionMode Enc { get; set; }
}
