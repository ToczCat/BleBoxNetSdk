using BleBoxNetSdk.AirSensor.Enums;

namespace BleBoxNetSdk.AirSensor.Models;

public record SensorApi
{
    public Geolocation MakeGeolocationCoarse {  get; set; }
}
