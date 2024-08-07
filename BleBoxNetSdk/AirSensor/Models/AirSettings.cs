using BleBoxNetSdk.AirSensor.Enums;
using BleBoxNetSdk.Common.Enums;

namespace BleBoxNetSdk.AirSensor.Models;

public record AirSettings
{
    public Mounting MountingPlace { get; set; }
    public Toggle DetailedView { get; set; }
}
