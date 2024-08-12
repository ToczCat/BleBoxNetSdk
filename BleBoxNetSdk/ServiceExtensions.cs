using BleBoxNetSdk.AirSensor;
using BleBoxNetSdk.Common;
using BleBoxNetSdk.Services;
using BleBoxNetSdk.Wrappers;
using Microsoft.Extensions.DependencyInjection;

namespace BleBoxNetSdk;

public static class ServiceExtensions
{
    public static IServiceCollection RegisterSdkServices(this IServiceCollection services)
    {
        services
            .AddSingleton<ISerializer, Serializer>()
            .AddSingleton<IHttpClient, BleHttpClient>()
            .AddSingleton<IApiHttpClient, ApiHttpClient>()
            .AddSingleton<ICommonApiClient, CommonApiClient>()
            .AddSingleton<IAirSensorApiClient, AirSensorApiClient>();

        return services;
    }
}
