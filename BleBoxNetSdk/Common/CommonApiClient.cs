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

    public async Task<Network?> GetNetworkInformation(Uri deviceAddress, CancellationToken cancellationToken = default)
    {
        var request = new NetworkInformation.Request();

        var response = await apiHttpClient.Send<NetworkInformation.ResponseResult>(deviceAddress, request, cancellationToken);

        return response;
    }

    public async Task<(Device? device, Network? network)> SetInternalAPSettings(
        Uri deviceAddress,
        bool apEnable,
        string? apSSID,
        string? apPassword,
        CancellationToken cancellationToken = default)
    {
        var request = new SetNetwork.Request(apEnable, apSSID, apPassword);

        var response = await apiHttpClient.Send<SetNetwork.ResponseResult>(deviceAddress, request, cancellationToken);

        return (response.Device, response.Network);
    }

    public async Task<AccessPoint[]?> PerformWiFiScan(Uri deviceAddress, CancellationToken cancellationToken = default)
    {
        var request = new WiFiScan.Request();

        var response = await apiHttpClient.Send<WiFiScan.ResponseResult>(deviceAddress, request, cancellationToken);

        return response.Ap;
    }

    public async Task<Network?> PerformWiFiConnect(
        Uri deviceAddress,
        string? ssid,
        string? password,
        CancellationToken cancellationToken = default)
    {
        var request = new ConnectWiFi.Request(ssid, password);

        var response = await apiHttpClient.Send<ConnectWiFi.ResponseResult>(deviceAddress, request, cancellationToken);

        return response;
    }

    public async Task<Network?> PerformWiFiDisconnect(Uri deviceAddress, CancellationToken cancellationToken = default)
    {
        var request = new DisconnectWiFi.Request();

        var response = await apiHttpClient.Send<DisconnectWiFi.ResponseResult>(deviceAddress, request, cancellationToken);

        return response;
    }
}