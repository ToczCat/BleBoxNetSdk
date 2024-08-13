using BleBoxNetSdk.Common.Enums;
using BleBoxNetSdk.Services;
using BleBoxNetSdk.WLightBox.Endpoints;
using BleBoxNetSdk.WLightBox.Enums;
using BleBoxNetSdk.WLightBox.Models;

namespace BleBoxNetSdk.WLightBox;

public class WLightBoxApiClient(IApiHttpClient apiHttpClient) : IWLightBoxApiClient
{
    public async Task<Rgbw?> ReadStateOfLighting(Uri deviceAddress, CancellationToken cancellationToken = default)
    {
        var request = new StateOfLighting.Request();

        var response = await apiHttpClient.Send<StateOfLighting.ResponseResult>(deviceAddress, request, cancellationToken);

        return response.Rgbw;
    }

    public async Task<Rgbw?> SetStateOfLighting(
        Uri deviceAddress,
        int effectId,
        string desiredColor,
        uint colorFade,
        uint effectFade,
        uint effectStep,
        CancellationToken cancellationToken = default)
    {
        var request = new SetStateOfLighting.Request(effectId, desiredColor, colorFade, effectFade, effectStep);

        var response = await apiHttpClient.Send<SetStateOfLighting.ResponseResult>(deviceAddress, request, cancellationToken);

        return response.Rgbw;
    }

    public async Task<RgbwExtended?> ReadExtendedStateOfLighting(Uri deviceAddress, CancellationToken cancellationToken = default)
    {
        var request = new ExtendedStateOfLighting.Request();

        var response = await apiHttpClient.Send<ExtendedStateOfLighting.ResponseResult>(deviceAddress, request, cancellationToken);

        return response.Rgbw;
    }

    public async Task<RgbwExtended?> SetExtendedStateOfLighting(
        Uri deviceAddress,
        int effectId,
        string desiredColor,
        uint colorFade,
        uint effectFade,
        uint effectStep,
        Dictionary<string, string> favColors,
        CancellationToken cancellationToken = default)
    {
        var request = new SetExtendedStateOfLighting.Request(effectId, desiredColor, colorFade, effectFade, effectStep, favColors);

        var response = await apiHttpClient.Send<SetExtendedStateOfLighting.ResponseResult>(deviceAddress, request, cancellationToken);

        return response.Rgbw;
    }

    public async Task<Rgbw?> Toggle(Uri deviceAddress, CancellationToken cancellationToken = default)
    {
        var request = new ToggleDevice.Request();

        var response = await apiHttpClient.Send<ToggleDevice.ResponseResult>(deviceAddress, request, cancellationToken);

        return response.Rgbw;
    }

    public async Task<Rgbw?> SetLastState(Uri deviceAddress, CancellationToken cancellationToken = default)
    {
        var request = new SetLastState.Request();

        var response = await apiHttpClient.Send<SetLastState.ResponseResult>(deviceAddress, request, cancellationToken);

        return response.Rgbw;
    }

    public async Task<Rgbw?> SetColor(Uri deviceAddress, string channels, CancellationToken cancellationToken = default)
    {
        var request = new SetColor.Request(channels);

        var response = await apiHttpClient.Send<SetColor.ResponseResult>(deviceAddress, request, cancellationToken);

        return response.Rgbw;
    }

    public async Task<Rgbw?> AdjustBrightness(Uri deviceAddress, Adjust adjust, string channels, CancellationToken cancellationToken = default)
    {
        var request = new AdjustBrightness.Request(adjust, channels);

        var response = await apiHttpClient.Send<AdjustBrightness.ResponseResult>(deviceAddress, request, cancellationToken);

        return response.Rgbw;
    }

    public async Task<Rgbw?> SetEffect(Uri deviceAddress, int effectId, CancellationToken cancellationToken = default)
    {
        var request = new SetEffect.Request(effectId);

        var response = await apiHttpClient.Send<SetEffect.ResponseResult>(deviceAddress, request, cancellationToken);

        return response.Rgbw;
    }

    public async Task<Rgbw?> SetColorWithFadeTime(
        Uri deviceAddress,
        string channels,
        uint timeMs,
        CancellationToken cancellationToken = default)
    {
        var request = new SetColorWithFade.Request(channels, timeMs);

        var response = await apiHttpClient.Send<SetColorWithFade.ResponseResult>(deviceAddress, request, cancellationToken);

        return response.Rgbw;
    }

    public async Task<Rgbw?> SetColorForATime(
        Uri deviceAddress,
        string channels,
        int timeS,
        CancellationToken cancellationToken = default)
    {
        var request = new SetColorForTime.Request(channels, timeS);

        var response = await apiHttpClient.Send<SetColorForTime.ResponseResult>(deviceAddress, request, cancellationToken);

        return response.Rgbw;
    }

    public async Task<Rgbw?> SetEffectForATime(
        Uri deviceAddress,
        int effectId,
        int timeS,
        CancellationToken cancellationToken = default)
    {
        var request = new SetEffectForTime.Request(effectId, timeS);

        var response = await apiHttpClient.Send<SetEffectForTime.ResponseResult>(deviceAddress, request, cancellationToken);

        return response.Rgbw;
    }

    public async Task<Rgbw?> SetColorWithFadeForATime(
        Uri deviceAddress,
        string channels,
        uint timeMs,
        int timeS,
        CancellationToken cancellationToken = default)
    {
        var request = new SetColorWithFadeForTime.Request(channels, timeMs, timeS);

        var response = await apiHttpClient.Send<SetColorWithFadeForTime.ResponseResult>(deviceAddress, request, cancellationToken);

        return response.Rgbw;
    }

    public async Task<Settings?> ReadSettings(Uri deviceAddress, CancellationToken cancellationToken = default)
    {
        var request = new SettingsState.Request();

        var response = await apiHttpClient.Send<SettingsState.ResponseResult>(deviceAddress, request, cancellationToken);

        return response.Settings;
    }

    public async Task<Settings?> WriteSettings(
        Uri deviceAddress,
        string deviceName,
        Toggle tunnelEnabled,
        Toggle statusLed,
        PwmFrequency pwmFrequency,
        ColorMode? colorMode = null,
        OutputMode? outputMode = null,
        ButtonMode? buttonMode = null,
        CancellationToken cancellationToken = default)
    {
        var request = new SettingsSet.Request(
            deviceName,
            tunnelEnabled,
            statusLed,
            pwmFrequency,
            colorMode,
            outputMode,
            buttonMode);

        var response = await apiHttpClient.Send<SettingsSet.ResponseResult>(deviceAddress, request, cancellationToken);

        return response.Settings;
    }
}
