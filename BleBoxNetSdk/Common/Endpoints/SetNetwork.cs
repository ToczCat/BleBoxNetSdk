using BleBoxModels.Common.Models;

namespace BleBoxNetSdk.Common.Endpoints;

internal static class SetNetwork
{
    internal class Request(bool apEnable, string? apSSID, string? apPasswd)
        : RequestBase(HttpMethod.Post, "/api/device/set", true)
    {
        public NetworkSet? Network { get; set; } = new()
        {
            ApEnable = apEnable,
            ApSSID = apSSID,
            ApPasswd = apPasswd
        };
    }

    internal record ResponseResult()
    {
        public Device? Device { get; set; }
        public Network? Network { get; set; }
    }
}
