namespace BleBoxNetSdk.Common.Endpoints;

internal class PerformUpdate
{
    internal class Request() : RequestBase(HttpMethod.Post, "/api/ota/update") { }

    internal class ResponseResult { }
}
