using BleBoxNetSdk.AirSensor.Endpoints;
using BleBoxModels.AirSensor.Enums;
using BleBoxModels.AirSensor.Models;
using BleBoxModels.Common.Enums;
using BleBoxNetSdk.Services;

namespace BleBoxNetSdk.AirSensor;

public class AirSensorApiClient(IApiHttpClient apiHttpClient) : IAirSensorApiClient
{
    public async Task<Air?> GetDeviceState(Uri deviceAddress, CancellationToken cancellationToken = default)
    {
        var request = new DeviceState.Request();

        var response = await apiHttpClient.Send<DeviceState.ResponseResult>(deviceAddress, request, cancellationToken);

        return response.Air;
    }

    public async Task<Air?> GetExtendedDeviceState(Uri deviceAddress, CancellationToken cancellationToken = default)
    {
        var request = new ExtendedDeviceState.Request();

        var response = await apiHttpClient.Send<ExtendedDeviceState.ResponseResult>(deviceAddress, request, cancellationToken);

        return response.Air;
    }

    public async Task<Runtime?> GetSensorRuntime(Uri deviceAddress, CancellationToken cancellationToken = default)
    {
        var request = new SensorRuntime.Request();

        var response = await apiHttpClient.Send<SensorRuntime.ResponseResult>(deviceAddress, request, cancellationToken);

        return response.Runtime;
    }

    public async Task<Air?> ForceSensorMeasurement(Uri deviceAddress, CancellationToken cancellationToken = default)
    {
        var request = new ForceMeasurement.Request();

        var response = await apiHttpClient.Send<ForceMeasurement.ResponseResult>(deviceAddress, request, cancellationToken);

        return response.Air;
    }

    public async Task<Settings?> ReadSettings(Uri deviceAddress, CancellationToken cancellationToken = default)
    {
        var request = new SettingsState.Request();

        var response = await apiHttpClient.Send<SettingsState.ResponseResult>(deviceAddress, request, cancellationToken);

        return response.Settings;
    }

    public async Task<Settings?> WriteSettings(
        string deviceName,
        Toggle tunnelEnabled,
        Toggle tunnelLogEnabled,
        Toggle statusLed,
        Geolocation geolocation,
        Mounting mounting,
        Toggle detailedView,
        Uri deviceAddress,
        CancellationToken cancellationToken = default)
    {
        var request = new SettingsSet.Request(
            deviceName,
            tunnelEnabled,
            tunnelLogEnabled,
            statusLed,
            geolocation,
            mounting,
            detailedView);

        var response = await apiHttpClient.Send<SettingsSet.ResponseResult>(deviceAddress, request, cancellationToken);

        return response.Settings;
    }
}
