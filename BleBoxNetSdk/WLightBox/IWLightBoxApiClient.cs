using BleBoxNetSdk.Common.Enums;
using BleBoxNetSdk.WLightBox.Enums;
using BleBoxNetSdk.WLightBox.Models;

namespace BleBoxNetSdk.WLightBox;
public interface IWLightBoxApiClient
{
    /// <summary>
    /// Adjust brightness
    /// </summary>
    /// <param name="deviceAddress"></param>
    /// <param name="adjust">inc or dec to increase or decrease brightness</param>
    /// <param name="channels">Color value in format: 4 channels (R)(G)(B)(W) or 1 channel (S), where
    /// every channel can get value between: 00-FF(HEX) (DEC: 0-255)</param>
    /// <param name="cancellationToken"></param>
    /// <exception cref="ArgumentNullException">Received json is null</exception>
    /// <exception cref="System.Text.Json.JsonException">Deserialization failed</exception>
    /// <exception cref="NotSupportedException">There is no compatible converter</exception>
    /// <exception cref="Exception">Request to API failed</exception>
    Task<Rgbw?> AdjustBrightness(Uri deviceAddress, Adjust adjust, string channels, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns information about mode, selected effect, color, transition times.
    /// Additionaly returns favorite colors and effects names
    /// </summary>
    /// <param name="deviceAddress"></param>
    /// <param name="cancellationToken"></param>
    /// <exception cref="ArgumentNullException">Received json is null</exception>
    /// <exception cref="System.Text.Json.JsonException">Deserialization failed</exception>
    /// <exception cref="NotSupportedException">There is no compatible converter</exception>
    /// <exception cref="Exception">Request to API failed</exception>
    Task<RgbwExtended?> ReadExtendedStateOfLighting(Uri deviceAddress, CancellationToken cancellationToken = default);

    /// <summary>
    /// Return device's specific settings
    /// </summary>
    /// <param name="deviceAddress"></param>
    /// <param name="cancellationToken"></param>
    /// <exception cref="ArgumentNullException">Received json is null</exception>
    /// <exception cref="System.Text.Json.JsonException">Deserialization failed</exception>
    /// <exception cref="NotSupportedException">There is no compatible converter</exception>
    /// <exception cref="Exception">Request to API failed</exception>
    Task<Settings?> ReadSettings(Uri deviceAddress, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns information about mode, selected effect, color and transition times
    /// </summary>
    /// <param name="deviceAddress"></param>
    /// <param name="cancellationToken"></param>
    /// <exception cref="ArgumentNullException">Received json is null</exception>
    /// <exception cref="System.Text.Json.JsonException">Deserialization failed</exception>
    /// <exception cref="NotSupportedException">There is no compatible converter</exception>
    /// <exception cref="Exception">Request to API failed</exception>
    Task<Rgbw?> ReadStateOfLighting(Uri deviceAddress, CancellationToken cancellationToken = default);

    /// <summary>
    /// Set color
    /// </summary>
    /// <param name="deviceAddress"></param>
    /// <param name="channels">Color value in format: 4 channels (R)(G)(B)(W) or 1 channel (S), where
    /// every channel can get value between: 00-FF(HEX) (DEC: 0-255)
    /// Use "--" instead hex value to keep channel unchanged - e.g.ff00--12.</param>
    /// <param name="cancellationToken"></param>
    /// <exception cref="ArgumentNullException">Received json is null</exception>
    /// <exception cref="System.Text.Json.JsonException">Deserialization failed</exception>
    /// <exception cref="NotSupportedException">There is no compatible converter</exception>
    /// <exception cref="Exception">Request to API failed</exception>
    Task<Rgbw?> SetColor(Uri deviceAddress, string channels, CancellationToken cancellationToken = default);

    /// <summary>
    /// Set color for given time (after given time returns to previous state)
    /// </summary>
    /// <param name="deviceAddress"></param>
    /// <param name="channels">Color value in format: 4 channels (R)(G)(B)(W) or 1 channel (S), where
    /// every channel can get value between: 00-FF(HEX) (DEC: 0-255)
    /// Use "--" instead hex value to keep channel unchanged - e.g.ff00--12.</param>
    /// <param name="timeS">Time in seconds for which the selected state will be set, after this time the last state will be restored</param>
    /// <param name="cancellationToken"></param>
    /// <exception cref="ArgumentNullException">Received json is null</exception>
    /// <exception cref="System.Text.Json.JsonException">Deserialization failed</exception>
    /// <exception cref="NotSupportedException">There is no compatible converter</exception>
    /// <exception cref="Exception">Request to API failed</exception>
    Task<Rgbw?> SetColorForATime(Uri deviceAddress, string channels, int timeS, CancellationToken cancellationToken = default);

    /// <summary>
    /// Set color with color fade time for given time (after given time returns to previous state)
    /// </summary>
    /// <param name="deviceAddress"></param>
    /// <param name="channels">Color value in format: 4 channels (R)(G)(B)(W) or 1 channel (S), where
    /// every channel can get value between: 00-FF(HEX) (DEC: 0-255)
    /// Use "--" instead hex value to keep channel unchanged - e.g.ff00--12.</param>
    /// <param name="timeMs">Time of transition from current color to desired color measured in milliseconds</param>
    /// <param name="timeS">Time in seconds for which the selected state will be set, after this time the last state will be restored</param>
    /// <param name="cancellationToken"></param>
    /// <exception cref="ArgumentNullException">Received json is null</exception>
    /// <exception cref="System.Text.Json.JsonException">Deserialization failed</exception>
    /// <exception cref="NotSupportedException">There is no compatible converter</exception>
    /// <exception cref="Exception">Request to API failed</exception>
    Task<Rgbw?> SetColorWithFadeForATime(
        Uri deviceAddress,
        string channels,
        uint timeMs,
        int timeS,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Set color with color fade time in milliseconds
    /// </summary>
    /// <param name="deviceAddress"></param>
    /// <param name="channels">Color value in format: 4 channels (R)(G)(B)(W) or 1 channel (S), where
    /// every channel can get value between: 00-FF(HEX) (DEC: 0-255)
    /// Use "--" instead hex value to keep channel unchanged - e.g.ff00--12.</param>
    /// <param name="timeMs">Time of transition from current color to desired color measured in milliseconds</param>
    /// <param name="cancellationToken"></param>
    /// <exception cref="ArgumentNullException">Received json is null</exception>
    /// <exception cref="System.Text.Json.JsonException">Deserialization failed</exception>
    /// <exception cref="NotSupportedException">There is no compatible converter</exception>
    /// <exception cref="Exception">Request to API failed</exception>
    Task<Rgbw?> SetColorWithFadeTime(Uri deviceAddress, string channels, uint timeMs, CancellationToken cancellationToken = default);

    /// <summary>
    /// Turning ON effect with given ID 
    /// </summary>
    /// <param name="deviceAddress"></param>
    /// <param name="effectId">No (ID) of Effect, where 0 means no effect</param>
    /// <param name="cancellationToken"></param>
    /// <exception cref="ArgumentNullException">Received json is null</exception>
    /// <exception cref="System.Text.Json.JsonException">Deserialization failed</exception>
    /// <exception cref="NotSupportedException">There is no compatible converter</exception>
    /// <exception cref="Exception">Request to API failed</exception>
    Task<Rgbw?> SetEffect(Uri deviceAddress, int effectId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Turning ON effect with given ID (after given time returns to previous state)
    /// </summary>
    /// <param name="deviceAddress"></param>
    /// <param name="effectId">No (ID) of Effect, where 0 means no effect</param>
    /// <param name="timeS">Time in seconds for which the selected state will be set, after this time the last state will be restored</param>
    /// <param name="cancellationToken"></param>
    /// <exception cref="ArgumentNullException">Received json is null</exception>
    /// <exception cref="System.Text.Json.JsonException">Deserialization failed</exception>
    /// <exception cref="NotSupportedException">There is no compatible converter</exception>
    /// <exception cref="Exception">Request to API failed</exception>
    Task<Rgbw?> SetEffectForATime(Uri deviceAddress, int effectId, int timeS, CancellationToken cancellationToken = default);

    /// <summary>
    /// Allows to set state of lighting - effect, color, transition times
    /// Additionaly allows to set extended parameters - favorite colors
    /// </summary>
    /// <param name="deviceAddress"></param>
    /// <param name="effectId">No (ID) of Effect, where 0 means no effect</param>
    /// <param name="desiredColor">Color value in format: 4 channels (R)(G)(B)(W) or 1 channel (S), where
    /// every channel can get value between: 00-FF(HEX) (DEC: 0-255)
    /// Use "--" instead hex value to keep channel unchanged - e.g.ff00--12.</param>
    /// <param name="colorFade">Time of transition from current color to desired color measured in milliseconds</param>
    /// <param name="effectFade">Time of color transition in current effect measured in milliseconds</param>
    /// <param name="effectStep">Duration of step (color) in current effect measured in milliseconds</param>
    /// <param name="favColors">Dictionary of favorite colors saved on device</param>
    /// <param name="cancellationToken"></param>
    /// <exception cref="ArgumentNullException">Received json is null</exception>
    /// <exception cref="System.Text.Json.JsonException">Deserialization failed</exception>
    /// <exception cref="NotSupportedException">There is no compatible converter</exception>
    /// <exception cref="Exception">Request to API failed</exception>
    Task<RgbwExtended?> SetExtendedStateOfLighting(
        Uri deviceAddress,
        int effectId,
        string desiredColor,
        uint colorFade,
        uint effectFade,
        uint effectStep,
        Dictionary<string, string> favColors,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Setting last color or effect
    /// </summary>
    /// <param name="deviceAddress"></param>
    /// <param name="cancellationToken"></param>
    /// <exception cref="ArgumentNullException">Received json is null</exception>
    /// <exception cref="System.Text.Json.JsonException">Deserialization failed</exception>
    /// <exception cref="NotSupportedException">There is no compatible converter</exception>
    /// <exception cref="Exception">Request to API failed</exception>
    Task<Rgbw?> SetLastState(Uri deviceAddress, CancellationToken cancellationToken = default);

    /// <summary>
    /// Allows to set desired color, effect and transition times
    /// </summary>
    /// <param name="deviceAddress"></param>
    /// <param name="effectId">No (ID) of Effect, where 0 means no effect</param>
    /// <param name="desiredColor">Color value in format: 4 channels (R)(G)(B)(W) or 1 channel (S), where
    /// every channel can get value between: 00-FF(HEX) (DEC: 0-255)
    /// Use "--" instead hex value to keep channel unchanged - e.g.ff00--12.</param>
    /// <param name="colorFade">Time of transition from current color to desired color measured in milliseconds</param>
    /// <param name="effectFade">Time of color transition in current effect measured in milliseconds</param>
    /// <param name="effectStep">Duration of step (color) in current effect measured in milliseconds</param>
    /// <param name="cancellationToken"></param>
    /// <exception cref="ArgumentNullException">Received json is null</exception>
    /// <exception cref="System.Text.Json.JsonException">Deserialization failed</exception>
    /// <exception cref="NotSupportedException">There is no compatible converter</exception>
    /// <exception cref="Exception">Request to API failed</exception>
    Task<Rgbw?> SetStateOfLighting(
        Uri deviceAddress,
        int effectId,
        string desiredColor,
        uint colorFade,
        uint effectFade,
        uint effectStep,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Turning ON/OFF (toggle) last color or effect
    /// </summary>
    /// <param name="deviceAddress"></param>
    /// <param name="cancellationToken"></param>
    /// <exception cref="ArgumentNullException">Received json is null</exception>
    /// <exception cref="System.Text.Json.JsonException">Deserialization failed</exception>
    /// <exception cref="NotSupportedException">There is no compatible converter</exception>
    /// <exception cref="Exception">Request to API failed</exception>
    Task<Rgbw?> Toggle(Uri deviceAddress, CancellationToken cancellationToken = default);

    /// <summary>
    /// Allow to set device's specific settings
    /// </summary>
    /// <param name="deviceAddress"></param>
    /// <param name="deviceName">Name of BleBox device/controller</param>
    /// <param name="tunnelEnabled">Allow to disable or enable function</param>
    /// <param name="statusLed">Allow to disable or enable function</param>
    /// <param name="pwmFrequency">Frequency of LED dimming. Useful for filmmakers</param>
    /// <param name="colorMode">Type of controlled appliance (type and quantity of LED strips)</param>
    /// <param name="outputMode">Type of output signal</param>
    /// <param name="buttonMode">Behaviour of connected button</param>
    /// <param name="cancellationToken"></param>
    /// <exception cref="ArgumentNullException">Received json is null</exception>
    /// <exception cref="System.Text.Json.JsonException">Deserialization failed</exception>
    /// <exception cref="NotSupportedException">There is no compatible converter</exception>
    /// <exception cref="Exception">Request to API failed</exception>
    Task<Settings?> WriteSettings(
        Uri deviceAddress,
        string deviceName,
        Toggle tunnelEnabled,
        Toggle statusLed,
        PwmFrequency pwmFrequency,
        ColorMode? colorMode = null,
        OutputMode? outputMode = null,
        ButtonMode? buttonMode = null,
        CancellationToken cancellationToken = default);
}