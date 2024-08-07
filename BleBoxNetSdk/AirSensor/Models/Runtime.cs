using BleBoxNetSdk.Common.JsonConverters;
using System.Text.Json.Serialization;

namespace BleBoxNetSdk.AirSensor.Models;

public record Runtime
{
    [JsonConverter(typeof(IntHoursToTimeSpanConverter))]
    public TimeSpan TimeH { get; set; }
}
