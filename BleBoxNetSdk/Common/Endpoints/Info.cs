using BleBoxNetSdk.Common.Models;

namespace BleBoxNetSdk.Common.Endpoints;

internal static class Info
{
    internal class Request() : RequestBase(HttpMethod.Get, "/info") { }

    internal class ResponseResult
    {
        public Device? Device { get; set; }
    }
}
