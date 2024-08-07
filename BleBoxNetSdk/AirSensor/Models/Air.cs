using BleBoxNetSdk.AirSensor.Enums;

namespace BleBoxNetSdk.AirSensor.Models;

public record Air
{
    public QualityLevel? AirQualityLevel { get; set; }
    public Sensor[]? Sensors { get; set; }
}

public record Sensor
{
    public string? Type { get; set; }
    public int? Value { get; set; }
    public QualityLevel? QualityLevel { get; set; }
    public Trend Trend { get; set; }
    public State State { get; set; }
    public int ElapsedTimeS { get; set; }
}