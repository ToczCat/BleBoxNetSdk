using BleBoxNetSdk.Common;
using BleBoxNetSdk.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BleBoxNetSdk;

public static class ServiceExtensions
{
    public static IServiceCollection RegisterSdkServices(this IServiceCollection services)
    {
        services
            .AddSingleton<ISerializer, Serializer>()
            .AddSingleton<IApiHttpClient, ApiHttpClient>()
            .AddSingleton<ICommonApiClient, CommonApiClient>();

        return services;
    }
}
