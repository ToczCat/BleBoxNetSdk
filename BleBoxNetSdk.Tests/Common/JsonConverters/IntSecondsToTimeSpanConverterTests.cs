using BleBoxModels.Common.JsonConverters;
using FluentAssertions;
using System.Text;
using System.Text.Json;

namespace BleBoxNetSdk.Tests.Common.JsonConverters;

internal class IntSecondsToTimeSpanConverterTests
{
    [TestCase(12)]
    [TestCase(0)]
    [TestCase(45389)]
    [TestCase(1)]
    public void should_read_value(int seconds)
    {
        var bytes = Encoding.UTF8.GetBytes(seconds.ToString());
        var reader = new Utf8JsonReader(bytes.AsSpan());
        reader.Read();
        var converter = PrepareConverter();

        var value = converter.Read(ref reader, typeof(TimeSpan), JsonSerializerOptions.Default);

        value.TotalSeconds.Should().Be(seconds);
    }

    [TestCase(87832)]
    [TestCase(0)]
    [TestCase(99)]
    [TestCase(1)]
    public void should_write_value(int seconds)
    {
        var converter = PrepareConverter();
        var buffer = new byte[64];
        using var memoryStream = new MemoryStream(buffer);
        using var writer = new Utf8JsonWriter(memoryStream);
        converter.Write(writer, TimeSpan.FromSeconds(seconds), JsonSerializerOptions.Default);
        writer.Flush();

        var value = Encoding.UTF8.GetString(buffer, 0, seconds.ToString().Length);

        value.Should().Be($"{seconds}");
    }

    internal IntSecondsToTimeSpanConverter PrepareConverter() => new IntSecondsToTimeSpanConverter();
}
