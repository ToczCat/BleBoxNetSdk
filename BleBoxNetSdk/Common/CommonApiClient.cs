using BleBoxNetSdk.Common.Endpoints;
using BleBoxNetSdk.Common.Models;
using BleBoxNetSdk.Services;

namespace BleBoxNetSdk.Common;

internal class CommonApiClient(IApiHttpClient apiHttpClient) : ICommonApiClient
{
    public async Task<Device?> Info(Uri deviceAddress, CancellationToken cancellationToken = default)
    {
        var request = new Info.Request();

        var response = await apiHttpClient.Send<Info.ResponseResult>(deviceAddress, request, cancellationToken);

        return response.Device;
    }

    public async Task<TimeSpan> GetDeviceUptime(Uri deviceAddress, CancellationToken cancellationToken = default)
    {
        var request = new DeviceUptime.Request();

        var response = await apiHttpClient.Send<DeviceUptime.ResponseResult>(deviceAddress, request, cancellationToken);

        return response.UpTimeS;
    }

    public async Task PerformDeviceUpdate(Uri deviceAddress, CancellationToken cancellationToken = default)
    {
        var request = new PerformUpdate.Request();

        await apiHttpClient.Send<PerformUpdate.ResponseResult>(deviceAddress, request, cancellationToken);
    }
}