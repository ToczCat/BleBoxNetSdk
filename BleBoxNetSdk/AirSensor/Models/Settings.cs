using BleBoxNetSdk.Common.Models;

namespace BleBoxNetSdk.AirSensor.Models;

public record Settings : SettingsBase
{
    public SensorApi? SensorApi { get; set; }
    public AirSettings? Air { get; set; }
}
