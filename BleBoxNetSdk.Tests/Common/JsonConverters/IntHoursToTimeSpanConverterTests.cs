using BleBoxNetSdk.Common.JsonConverters;
using FluentAssertions;
using System.Text.Json;
using System.Text;

namespace BleBoxNetSdk.Tests.Common.JsonConverters;

internal class IntHoursToTimeSpanConverterTests
{
    [TestCase(12)]
    [TestCase(0)]
    [TestCase(45389)]
    [TestCase(1)]
    public void should_read_value(int hours)
    {
        var bytes = Encoding.UTF8.GetBytes(hours.ToString());
        var reader = new Utf8JsonReader(bytes.AsSpan());
        reader.Read();
        var converter = PrepareConverter();

        var value = converter.Read(ref reader, typeof(TimeSpan), JsonSerializerOptions.Default);

        value.TotalHours.Should().Be(hours);
    }

    [TestCase(87832)]
    [TestCase(0)]
    [TestCase(99)]
    [TestCase(1)]
    public void should_write_value(int hours)
    {
        var converter = PrepareConverter();
        var buffer = new byte[64];
        using var memoryStream = new MemoryStream(buffer);
        using var writer = new Utf8JsonWriter(memoryStream);
        converter.Write(writer, TimeSpan.FromHours(hours), JsonSerializerOptions.Default);
        writer.Flush();

        var value = Encoding.UTF8.GetString(buffer, 0, hours.ToString().Length);

        value.Should().Be($"{hours}");
    }

    internal IntHoursToTimeSpanConverter PrepareConverter() => new IntHoursToTimeSpanConverter();
}
