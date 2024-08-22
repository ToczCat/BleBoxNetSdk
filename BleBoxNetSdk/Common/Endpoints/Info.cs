using BleBoxModels.Common.Models;

namespace BleBoxNetSdk.Common.Endpoints;

internal static class Info
{
    internal class Request() : RequestBase(HttpMethod.Get, "/info") { }

    internal record ResponseResult
    {
        public Device? Device { get; set; }
    }
}
